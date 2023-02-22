using System.Collections;
using System.Globalization;
using SameDayDelivery.VanControls;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SameDayDelivery.Controls
{
    public class GameWatcher : MonoBehaviour
    {
        [Header("References")]
        public CarControls carControls;
        public PlayerControlManager playerControls;
        public GameObject sheldonCam;
        public GameObject vanCam;

        [Header("Gameplay")]
        public static int currentScore;
        public float TimeLeft;
        public bool TimerOn; //bool to make sure timer does not go below 0
        public string currControls;
        public static int packagesDelivered;
        public int packagesNeeded;
        public float timeSinceLastDelivery;
        public static int currLevel;
        public static int zergCoinsGained;//How much currency the player currently has 

        [Header("UI Elements")]
        public TMP_Text timerText; //how the timer is displayed
        public TMP_Text scoreText; //how the score is displayed
        public TMP_Text levelText; //how the current day is displayed
        public GameObject failNotification; //appears when the player fails
        public GameObject successNotification; //appears when the player passes
        private bool levelFailed; //used to tell if player failed a level 

        // Start is called before the first frame update
        private void Start()
        {
            LevelSetup();
        }

        // Update is called once per frame
        private void Update()
        {
            if (TimeLeft > 0) //if the player still has time decrease the remaining time then update the UI 
            {
                TimerOn = true;
                TimeLeft -= Time.deltaTime;
                UpdaterUI(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                TimerOn = false;
                levelFailed = true;
                failNotification.SetActive(true);
                StartCoroutine(GgGoNext());
            }

            //if the packages delivered exceeds the necessary number to beat a level go to the success screen
            if (packagesDelivered >= packagesNeeded)
                StartCoroutine(LevelComplete());

            timeSinceLastDelivery += Time.deltaTime;
        }

        private void LevelSetup() //resetting values to their correct states upon starting the scene. 
        {
            TimerOn = true; //begin the timer 
            failNotification.SetActive(false); //make sure that the player cannot see the pass or fail notifications 
            successNotification.SetActive(false);
            sheldonCam.SetActive(true); //turn on the sheldon cam so that the camera correctly starts with the sheldon
            currentScore = 2500; //reset the current score to 0 
            packagesDelivered = 0; //reset the packages delivered to 0 
            zergCoinsGained = 0; 
            levelText.text = "Day: " + currLevel;

            SwitchControlsToPlayer();
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

        private void SwitchControlsToVan()
        {
            playerControls.enabled = false;
            carControls.enabled = true;
            carControls.ChuteActivation();
            sheldonCam.SetActive(false);
            vanCam.SetActive(true);
            currControls = "Van";
        }

        private void SwitchControlsToPlayer()
        {
            carControls.ChuteActivation();
            carControls.currSpeed = 0;
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
            UpgradeScreen.zergCoins = UpgradeScreen.zergCoins + zergCoinsGained; //add the players gained zerg coins to the upgrade screen 
            SceneManager.LoadScene("FailScreen");
        }

        private IEnumerator
            LevelComplete() //delay loading the success screen so that players can process that they passed
        {
            TimerOn = false;
            successNotification.SetActive(true);
            yield return new WaitForSeconds(2);
            StopAllCoroutines();
            zergCoinsGained = currentScore / 50;
            UpgradeScreen.zergCoins = UpgradeScreen.zergCoins + zergCoinsGained; //add the players gained zerg coins to the upgrade screen 
            currLevel++;
            SceneManager.LoadScene("PassScreen");
        }

        public void PackageReceived() //if a package was received the player's score will be updated and saved here
        {
            packagesDelivered++;
            if (timeSinceLastDelivery <= 20) //speedy delivery bonus
            {
                Debug.Log("SPEEDY DELIVERY!");
                currentScore = currentScore + 150;
            }
            else if (timeSinceLastDelivery >= 60) //slow delivery penalty
            {
                Debug.Log("SLOW DELIVERY");
                currentScore = currentScore + 75;
            }
            else
            {
                Debug.Log("Standard Delivery");
                currentScore = currentScore + 100;
            }

            timeSinceLastDelivery = 0; //make sure to reset time since delivery so that the player may get delivery bonuses 
        }
    }
}