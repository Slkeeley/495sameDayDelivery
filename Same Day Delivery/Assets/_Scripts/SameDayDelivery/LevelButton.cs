using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using TMPro; 

public class LevelButton : MonoBehaviour
{
    [Header("Level Data")]
    public SameDayDelivery.ScriptableObjects.LevelData levelData; 
    [SerializeField] private string levelName;
    [SerializeField] private int levelNumber;
    [SerializeField] private TMP_Text lvlNameText;
    [SerializeField] private Image image;

    [Header("References")]
    private Button button;


    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        //Attach scriptable object values to this upgrade button to reflect what it does
        levelName = levelData.levelName;
        image.sprite = levelData.screenshot;
        levelNumber = levelData.levelNumber; 
        //Create the UI based off of the values for each upgrade
        lvlNameText.text = levelName;

    }

    public void Update()
    {
        if (!levelData.unlocked) button.interactable = false;
        else button.interactable = true; 
    }

    public void loadSelectedLevel()
    {
        SceneManager.LoadScene(levelNumber); //select the level to load in the editor so we only need to use 1 function 
    }

}
