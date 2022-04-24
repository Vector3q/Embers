using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSpecial : MonoBehaviour
{
    public GameObject planeSynthesis;
    static public bool Detected = false;

    /// <summary>
    /// 当检测到点击到特殊的物品时
    /// </summary>
    public void detectSomething()
    {
        if(PlayerController.Selected_Equipment.itemName == "paper")
        {
            planeSynthesis.SetActive(true);
            Detected = true;
        }
    }
    public void SynthesisWord()
    {
        Debug.Log(1);
        if (planeSynthesis.gameObject.activeSelf)
        {
            if (WordSynthesis.leftword == null && PlayerController.Selected_Equipment.isword)
            {
                Debug.Log(1);
                WordSynthesis.leftword = PlayerController.Selected_Equipment;
            }
            else if (WordSynthesis.leftword != null && PlayerController.Selected_Equipment.isword)
            {
                WordSynthesis.rightword = PlayerController.Selected_Equipment;
            }
        }
    }
}
