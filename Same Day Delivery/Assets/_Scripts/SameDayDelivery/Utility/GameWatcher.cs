using System.Collections;
using System.Globalization;
using SameDayDelivery.VanControls;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events; 

namespace SameDayDelivery.Controls
{
    public class GameWatcher : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SameDayDelivery.ScriptableObjects.GameData data; 
        public CarControls carControls;
        public PlayerControlManager playerControls;
        public GameObject sheldonCam;
        public GameObject vanCam;
        [SerializeField] private GameObject van;

        [Header("Gameplay")]
        public static int currentScore;
        public float TimeLeft;
        public bool TimerOn; //bool to make sure timer does not go below 0
        public string currControls;
        public int packagesDelivered;
        public int packagesNeeded;
        public float timeSinceLastDelivery;
        public static int currLevel;
        public int zergCoinsGained;//How much currency the player currently has 

        [Header("UI Elements")]
        public TMP_Text timerText; //how the timer is displayed
        public TMP_Text scoreText; //how the score is displayed
        public TMP_Text levelText; //how the current day is displayed
        public TMP_Text zergCoinsText; //how the current day is displayed
        public TMP_Text deliveryText;
        public TMP_Text packagesText; //display how many packages the player still needs to deliver
        private Color dtColor; 
        public GameObject failNotification; //appears when the player fails
        public GameObject successNotification; //appears when the player passes

        [Header("Events")]
        public UnityEvent goToFailScreen; 
        public UnityEvent goToPassScreen;

        private bool driftingForward = false;
        private float currSpeed; 
        // Start is called before the first frame update
        private void Start()
        {
            LevelSetup();
        }

        // Update is called once per frame
        private void  FixedUpdate()
        {
            if (TimeLeft > 0) //if the player still has time decrease the remaining time then update the UI 
            {
                TimerOn = true;
                TimeLeft -= Time.fixedDeltaTime;
                UpdaterUI(TimeLeft);
            }
            else//player runs out of time and has failed the level 
            {
                TimeLeft = 0;
                TimerOn = false;
                failNotification.SetActive(true);
                StartCoroutine(GgGoNext());
            }

            //if the packages delivered exceeds the necessary number to beat a level go to the success screen
            if (packagesDelivered >= packagesNeeded)
                StartCoroutine(LevelComplete());

            timeSinceLastDelivery += Time.fixedDeltaTime;

            if(driftingForward)
            {
                Debug.Log("Drift Update");
                if (currSpeed > 0)
                {
                    van.transform.Translate(Vector3.forward * currSpeed * Time.fixedDeltaTime);
                    currSpeed -= 0.05f;
                }
                else driftingForward = false; 

            }


            updateUI(); 
        }

        private void LevelSetup() //resetting values to their correct states upon starting the scene. 
        {
            TimerOn = true; //begin the timer 
            failNotification.SetActive(false); //make sure that the player cannot see the pass or fail notifications 
            successNotification.SetActive(false);
            sheldonCam.SetActive(true); //turn on the sheldon cam so that the camera correctly starts with the sheldon
            currentScore = 0; //reset the current score to 0 
            packagesDelivered = 0; //reset the packages delivered to 0 
            zergCoinsGained = 0; 
            levelText.text = "Day: " + currLevel;
            dtColor = new Color(1f, 1f, 1f, 1f);
            deliveryText.text = ""; 
            SwitchControlsToPlayer();
        }

        void updateUI()
        {
            zergCoinsText.text = zergCoinsGained.ToString();
            packagesText.text = (packagesNeeded - packagesDelivered).ToString(); 
        }
        public void SwitchControls() //handle the control scheme switching here
        {
            switch (currControls)
            {
                case "Van":
                    SwitchControlsToPlayer();
                  //  StartCoroutine(driftToStop()); 
                    break;
                case "Player":
                    SwitchControlsToVan();
                    break;
            }
        }

        private void SwitchControlsToVan()
        {
            playerControls.enabled = false;
            carControls.enabled = true;
            carControls.ChuteActivation();           
            carControls.motorStart?.Invoke(); //play the sound effect for the van starting when the player enters. 
            sheldonCam.SetActive(false);
            vanCam.SetActive(true);
            currControls = "Van";
        }

        private void SwitchControlsToPlayer()
        {
            carControls.ChuteActivation();
            if (carControls.currSpeed > 5)
            {
                currSpeed = 10;
                driftingForward = true;
            }
            carControls.currSpeed = 0;      
            carControls.stopNoises?.Invoke();  //stop playing car audio when sheldon exits the van 
            carControls.enabled = false;
            playerControls.enabled = true;
            vanCam.SetActive(false);
            sheldonCam.SetActive(true);
            currControls = "Player";

        }

        private void UpdaterUI(float currentTime) //used to update the timer text on screen to accurately reflect how much time is left 
        {
            currentTime += 1;
            var minutes = Mathf.FloorToInt(currentTime / 60).ToString();
            var seconds = Mathf.FloorToInt(currentTime % 60).ToString();
            var score = currentScore.ToString(CultureInfo.CurrentCulture);

            timerText.text = $"{minutes:00} : {seconds:00}";
            scoreText.text = $"Score: {score}";
        }

        private IEnumerator GgGoNext() //Coroutine to delay loading the next so that the player can process that they failed/
        {
            yield return new WaitForSeconds(2.0f);
            StopAllCoroutines(); //stop coroutines so that the fail screen isn't loaded multiple times. 
            zergCoinsGained = currentScore / 50;
            data.money = data.money + zergCoinsGained; //add the players gained zerg coins to the upgrade screen 
            goToFailScreen?.Invoke(); 
        }

        private IEnumerator
            LevelComplete() //delay loading the success screen so that players can process that they passed
        {
            TimerOn = false;
            successNotification.SetActive(true);
            yield return new WaitForSeconds(2);
            StopAllCoroutines();
            data.money = data.money + zergCoinsGained; //add the players gained zerg coins to the upgrade screen 
            currLevel++;
            goToPassScreen?.Invoke();
        }

        public void PackageReceived() //if a package was received the player's score will be updated and saved here
        {
            packagesDelivered++;
            if (timeSinceLastDelivery <= 20) //speedy delivery bonus
            {
                dtColor =  new Color(0.04669785f, 1f, 1f, 1f);
                deliveryText.color = dtColor;
                deliveryText.text = "Speedy Delivery! +150";
                currentScore = currentScore + 150;
                zergCoinsGained = zergCoinsGained + 3;
                Debug.Log(zergCoinsGained + " Zerg Coins Gained So Far");
                StartCoroutine(displayDeliveryMessage()); 
            }
            else if (timeSinceLastDelivery >= 60) //slow delivery penalty
            {
                dtColor = new Color(1f, 0f, 0.1349077f, 1f);
                deliveryText.color = dtColor;
                deliveryText.text = "Slow Delivery +75";
                currentScore = currentScore + 75;
                zergCoinsGained = zergCoinsGained + 1;
                Debug.Log(zergCoinsGained + " Zerg Coins Gained So Far");
                StartCoroutine(displayDeliveryMessage());
            }
            else
            {
                dtColor = new Color(0.6f, 0.6f,0.6f, 1f);
                deliveryText.color = dtColor;
                deliveryText.text = "Standard Delivery! +100";
                currentScore = currentScore + 100;
                zergCoinsGained = zergCoinsGained + 2;
                Debug.Log(zergCoinsGained + " Zerg Coins Gained So Far");
                StartCoroutine(displayDeliveryMessage());
            }

            timeSinceLastDelivery = 0; //make sure to reset time since delivery so that the player may get delivery bonuses 
        }
        
        
        IEnumerator displayDeliveryMessage()
        {
            yield return new WaitForSeconds(2.0f);
            deliveryText.text = ""; 
        }

    }


}