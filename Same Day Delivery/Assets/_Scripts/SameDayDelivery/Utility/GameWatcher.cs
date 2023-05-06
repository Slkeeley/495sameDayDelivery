using System.Collections;
using System.Globalization;
using SameDayDelivery.VanControls;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SameDayDelivery.Controls
{
    public class GameWatcher : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private ScriptableObjects.GameData data;
        [SerializeField] private ScriptableObjects.UpgradeItem earlyAlarm;
        [SerializeField] private ScriptableObjects.UpgradeItem payRaise;
        [SerializeField] private ScriptableObjects.UpgradeItem employeeOfTheMonth;
        [SerializeField] public ScriptableObjects.UpgradeItem evilIntentions;
        [SerializeField] private UI.gameplayUI UI; 
        public VanController carControls;
        public PlayerControlManager playerControls;
        public GameObject sheldonCam;
        public GameObject vanCam;
        [SerializeField] private GameObject van;

        [Header("Gameplay Values")]
        public int levelNumber;
        public int currentScore;
        public float TimeLeft;
        public bool TimerOn; //bool to make sure timer does not go below 0
        public string currControls;
        public int packagesDelivered;
        public int packagesNeeded;
        public float timeSinceLastDelivery;
        public static int scoreEarned;
        public int zergCoinsGained;//How much currency the player has gained since the start of the level
        

        [Header("Events")]
        //Scene Events
        public UnityEvent goToFailScreen; 
        public UnityEvent goToPassScreen;
        //UI Events; 
        public UnityEvent danStart;
        public UnityEvent workFaster;
        public UnityEvent oneMinute;
        public UnityEvent propHit;  

        //Privaye vars 
        public bool driftingForward = false;
        private float currSpeed;
        private bool payRaised;
        private bool minuteLeft = false;
        [Header("Time | Score | Money")]
        public float _speedyDeliveryTime = 30f;
        public float _lateDeliveryTime = 60f;
        public int _speedyDeliveryScore = 150;
        public int _speedyDeliveryCoins = 3;
        public int _lateDeliveryScore = 75;
        public int _lateDeliveryMoney = 1;
        public int _standardDeliveryScore = 100;
        public int _standardDeliveryMoney = 2;


        private void Awake()
        {
            upgradeAttachment(); 
        }
        private void Start()
        {
            LevelSetup();
            danStart?.Invoke(); 
        }

        // Update is called once per frame
        private void  FixedUpdate()
        {
            if (TimeLeft > 0) //if the player still has time decrease the remaining time then update the UI 
            {
                TimerOn = true;
                TimeLeft -= Time.fixedDeltaTime;
                UpdaterTimer(TimeLeft);
            }
            else//player runs out of time and has failed the level 
            {
                TimeLeft = 0;
                TimerOn = false;
                StartCoroutine(GgGoNext());
            }
            if (TimeLeft <= 60 && !minuteLeft)
            {
                minuteLeft = true;
                oneMinute?.Invoke(); 
            }
      
            

            if (packagesDelivered >= packagesNeeded) StartCoroutine(LevelComplete());  //if the packages delivered exceeds the necessary number to beat a level go to the success screen

            timeSinceLastDelivery += Time.fixedDeltaTime;//measure the time between deliveries so the player can receive a bonus/penalty

            if(driftingForward)  driftToStop();//move the van forward a bit if the player exited a moving vehicle

            updateUI(); 
        }

        private void LevelSetup() //resetting values to their correct states upon starting the scene. 
        {
            TimerOn = true; //begin the timer 
            currentScore = 0; //reset the current score to 0 
            packagesDelivered = 0; //reset the packages delivered to 0 
            zergCoinsGained = 0; 
            UI.levelText.text = "Day: " + levelNumber;
            UI.deliveryText.text = "";
            scoreEarned = 0; 
            zergCoinsGained = 0; 
            SwitchControlsToPlayer();
        }
        void upgradeAttachment()
        {
            earlyAlarm = data.upgradeLookupTable.upgrades[3];
            payRaise = data.upgradeLookupTable.upgrades[8];
            employeeOfTheMonth = data.upgradeLookupTable.upgrades[8];
            evilIntentions = data.upgradeLookupTable.upgrades[8];
            checkUpgradePurchaseValues(); 
        }

        void checkUpgradePurchaseValues()//checks if an upgrade is purchased, if so add its value to the default values. 
        {
            if (earlyAlarm.purchased) TimeLeft = TimeLeft + 10;
            if (payRaise.purchased) payRaised = true;

        }

        void updateUI()//update these values in the UI 
        {
            UI.zergCoinsText.text = zergCoinsGained.ToString();
            UI.packagesText.text = (packagesNeeded - packagesDelivered).ToString(); 
        }
        public void SwitchControls() //handle the control scheme switching here
        {
            switch (currControls)
            {
                case "Van":
                    SwitchControlsToPlayer();
                    break;
                case "Player":
                    SwitchControlsToVan();
                    break;
            }
        }

        private void SwitchControlsToVan()//enter the van and switch the control scheme to driving
        {
            playerControls.enabled = false;
            carControls.enabled = true;
            carControls.rb.velocity = Vector3.zero;
            // carControls.rb.isKinematic = false;
            carControls.ChuteActivation();           
            carControls.motorStart?.Invoke(); //play the sound effect for the van starting when the player enters. 
            sheldonCam.SetActive(false);
            vanCam.SetActive(true);
            currControls = "Van";
        }

        private void SwitchControlsToPlayer()//exit the van and switch the control scheme to the player
        {
            carControls.ChuteActivation();
            if (carControls.rb.velocity.magnitude > 5)
            {
                currSpeed = 10;
                driftingForward = true;
                // carControls.rb.isKinematic = true;
            }
            // else carControls.rb.isKinematic = true; 
            carControls.stopNoises?.Invoke();  //stop playing car audio when sheldon exits the van 
            carControls.enabled = false;
            playerControls.enabled = true;
            vanCam.SetActive(false);
            sheldonCam.SetActive(true);
            currControls = "Player";

        }

        private void UpdaterTimer(float currentTime) //used to update the timer text on screen to accurately reflect how much time is left 
        {
            currentTime += 1;
            var minutes = Mathf.FloorToInt(currentTime / 60).ToString();
            var seconds = Mathf.FloorToInt(currentTime % 60).ToString();
            var score = currentScore.ToString(CultureInfo.CurrentCulture);

            UI.timerText.text = $"{minutes:00}:{seconds:00}";
            UI.scoreText.text = $"Score: {score}";
        }

        void driftToStop()//function for the car to drift to a stop if sheldon leaves while the car is still moving 
        {
            // Debug.Log("Drifting To Stop");
            if (currSpeed > 0)
            {
                van.transform.Translate(Vector3.forward * (currSpeed * Time.fixedDeltaTime));
                currSpeed -= 0.05f;
            }
            else driftingForward = false;
            
        }


        private IEnumerator GgGoNext() //Coroutine to delay loading the next so that the player can process that they failed/
        {
            UI.failNotification.SetActive(true); 
            yield return new WaitForSeconds(2.0f);
            StopAllCoroutines(); //stop coroutines so that the fail screen isn't loaded multiple times. 
            if (payRaised)
            {
                zergCoinsGained = zergCoinsGained + (currentScore / 50);
                data.money = ((zergCoinsGained / 10) + zergCoinsGained) + data.money;
                SameDayDelivery.UI.scoreDisplay.coinsGained = (zergCoinsGained / 10) + zergCoinsGained;
            }
            else
            {
                zergCoinsGained = zergCoinsGained + (currentScore / 50);
                data.money = data.money + zergCoinsGained;
                SameDayDelivery.UI.scoreDisplay.coinsGained = zergCoinsGained;
            }//add the players gained zerg coins to the upgrade screen 
            scoreEarned = currentScore; 
            goToFailScreen?.Invoke(); 
        }

        private IEnumerator LevelComplete() //delay loading the success screen so that players can process that they passed
        {
            TimerOn = false;
            UI.successNotification.SetActive(true);
            yield return new WaitForSeconds(2);
            StopAllCoroutines();
           
            if (payRaised)
            {
                zergCoinsGained = zergCoinsGained + (currentScore / 50);
                data.money = ((zergCoinsGained / 10) + zergCoinsGained) + data.money;
                SameDayDelivery.UI.scoreDisplay.coinsGained = (zergCoinsGained / 10) + zergCoinsGained;
            }
            else
            {
                zergCoinsGained = zergCoinsGained + (currentScore / 50);
                data.money = data.money + zergCoinsGained; 
                SameDayDelivery.UI.scoreDisplay.coinsGained = zergCoinsGained;
            }//add the players gained zerg coins to the upgrade screen 
            scoreEarned = currentScore;
            data.levelSelectTable.levels[levelNumber].unlocked=true; 
            goToPassScreen?.Invoke();//invoke the event that moves to the success screen 
        }

        public void PackageReceived() //if a package was received the player's score will be updated and saved here
        {
            packagesDelivered++;
            if (timeSinceLastDelivery <= _speedyDeliveryTime) //speedy delivery bonus
            {              
                UI.deliveryMessage(1);
                currentScore += _speedyDeliveryScore; 
                zergCoinsGained += _speedyDeliveryCoins;

            }
            else if (timeSinceLastDelivery >= _lateDeliveryTime) //slow delivery penalty
            {
                UI.deliveryMessage(2);
                workFaster?.Invoke(); 
                currentScore += _lateDeliveryScore;
                zergCoinsGained += _lateDeliveryMoney;
            }
            else
            {
                UI.deliveryMessage(3);
                currentScore += _standardDeliveryScore;
                zergCoinsGained += _standardDeliveryMoney;
            }
            timeSinceLastDelivery = 0; //make sure to reset time since delivery so that the player may get delivery bonuses 
        }

    }


}