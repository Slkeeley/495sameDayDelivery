using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class scoreDisplay : MonoBehaviour// this is used to display the players score, packages and 
{
    public TMP_Text mostRecentScore;
    public TMP_Text packagesDelivered;  
    // Start is called before the first frame update
    void Start()
    {
        mostRecentScore.text = "Your Score: "+ GameWatcher.currScore.ToString(); 
        packagesDelivered.text = "Packages Delivered: " + GameWatcher.packagesDelivered.ToString();
        //put zBucks here
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }




}
