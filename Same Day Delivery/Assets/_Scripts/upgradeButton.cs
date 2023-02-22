using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/upgradeButton", order = 1)]
public class upgradeButton : ScriptableObject
{
    public string upgradeName;
    public int price;
    public bool purchased; 
}
