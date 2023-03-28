using System.Collections;
using SameDayDelivery.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

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

        private void Awake()
        {
            gameWatcher = GameObject.Find("GameWatcher").GetComponent<GameWatcher>(); 
        }
        private void Start()
        {
            playerInVan = false;
            enterText.SetActive(false);
            SetPlayerObj();
        }

        public void CheckEnterExitVan(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
            if (playerInVan)
            {
                ExitVan();
            }
            else if (nearDoors)
            {
                EnterVan();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                nearDoors = true;
                UpdateEnterText();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                nearDoors = false;
                UpdateEnterText();
            }
        }

        private void UpdateEnterText()
        {
            if (nearDoors && !playerInVan)
            {
                enterText.SetActive(true);
            }
            else
            {
                enterText.SetActive(false);
            }
        }

        private void SetPlayerObj() //setup the correct connection to the player obj so that we can reference it later
        {
            if (!player)
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
            playerInVan = false;
            StartCoroutine(ExitDelay());
        }

        private IEnumerator ExitDelay() //used to stop the player from flickering in and out of reality
        {
            yield return new WaitForSeconds(1);
            playerInVan = true;
        }


    }

}