using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSpecial : MonoBehaviour
{
    static public GameObject planeSynthesis;
    /// <summary>
    /// 当检测到点击到特殊的物品时
    /// </summary>
    public void detectSomething()
    {
        if(PlayerController.Selected_Equipment.itemName == "paper")
        {
            planeSynthesis.SetActive(true);
        }
    }
}
