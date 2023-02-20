using System.Collections;
using SameDayDelivery.Controls;
using UnityEngine;

namespace SameDayDelivery.VanControls
{
    public class VanDoors : MonoBehaviour
    {
        public bool nearDoors;
        public bool playerInVan;
        public GameObject player;
        public GameObject enterText;

        public GameWatcher gameWatcher; //used to tell the game when to switch control schemes

        public Transform playerExitPos;

        void Start()
        {
            playerInVan = true;
            enterText.SetActive(false);
            SetPlayerObj();
        }

        // Update is called once per frame
        void Update()
        {
            if (nearDoors && !playerInVan) enterText.SetActive(true);
            else enterText.SetActive(false);

            if (!Input.GetKeyDown(KeyCode.F)) return;

            if (playerInVan) ExitVan();
            else if (nearDoors) EnterVan();
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
                nearDoors = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                nearDoors = false;
        }

        private void SetPlayerObj() //setup the correct connection to the player obj so that we can reference it later
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = playerExitPos.position;
        }

        private void ExitVan() //upon exit teleport the player to the correct position and switch the controls
        {
            player.transform.position = playerExitPos.position;
            player.SetActive(true);
            playerInVan = false;
            gameWatcher.SwitchControls();
        }

        private void EnterVan() //upon entering disable the player and then switch the controls to the van controls
        {
            player.SetActive(false);
            enterText.SetActive(false);
            gameWatcher.SwitchControls();
            StartCoroutine(ExitDelay());
        }

        private IEnumerator ExitDelay() //used to stop the player from flickering in and out of reality
        {
            yield return new WaitForSeconds(1);
            playerInVan = true;
        }


    }

}