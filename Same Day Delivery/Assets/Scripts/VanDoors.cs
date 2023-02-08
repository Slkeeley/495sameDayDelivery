using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanDoors : MonoBehaviour
{
    public bool nearDoors;
    public bool playerInVan; 
    public GameObject player;
    public GameObject enterText;

    public GameWatcher gw; //used to tell the game when to switch control schemes
    
    public Transform playerExitPos;

    void Start()
    {
        playerInVan = true;
        enterText.SetActive(false); 
        setPlayerObj(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (nearDoors&&!playerInVan) enterText.SetActive(true);
        else enterText.SetActive(false); 

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(playerInVan)
            {
                exitVan();
            }
            else
            {
                if(nearDoors)
                {
                  enterVan(); 
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Player")
        {
            nearDoors = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            nearDoors = false;
        }
    }

    void setPlayerObj()//setup the correct connection to the player obj so that we can reference it later
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerExitPos.position;
        player.SetActive(false);
    }
    void exitVan()//upon exit teleport the player to the correct position and switch the controls
    {
        player.transform.position = playerExitPos.position;
        player.SetActive(true);
        playerInVan = false;
        gw.switchControls(); 
    }

    void enterVan()//upon entering disable the player and then switch the controls to the van controls
    {
        player.SetActive(false);
        enterText.SetActive(false);
        gw.switchControls(); 
        StartCoroutine(exitDelay());
    }

    IEnumerator exitDelay()//used to stop the player from flickering in and out of reality
    {
        yield return new WaitForSeconds(1);
        playerInVan = true; 
    }


}
