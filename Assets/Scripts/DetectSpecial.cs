using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSpecial : MonoBehaviour
{
    static public GameObject planeSynthesis;
    /// <summary>
    /// ����⵽������������Ʒʱ
    /// </summary>
    public void detectSomething()
    {
        if(PlayerController.Selected_Equipment.itemName == "paper")
        {
            planeSynthesis.SetActive(true);
        }
    }
}
