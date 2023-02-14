using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class scoreDisplay : MonoBehaviour
{
    public TMP_Text mostRecentScore;
    public TMP_Text packagesDelivered;  
    // Start is called before the first frame update
    void Start()
    {
        mostRecentScore.text = "Your Score: "+ GameWatcher.currScore.ToString(); 
        packagesDelivered.text = "Packages Delivered: " + GameWatcher.packagesDelivered.ToString(); 
    }


}
