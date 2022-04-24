using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ÎÄ×ÖºÏ³É
/// </summary>
public class WordSynthesis : MonoBehaviour
{
    public Item leftword;
    public Item rightword;
    public Item successword;
    public Image leftImage;
    public Image rightImage;
    public Image successImage;

    public void Synthesis_autumn()
    {
        if (DetectSpecial.planeSynthesis.activeSelf == true)
        {
            if(leftword.itemName == "fire" && rightword.itemName == "seed")
            {
                leftImage.gameObject.SetActive(false);
                rightImage.gameObject.SetActive(false);
                successImage.gameObject.SetActive(true);
            }
        }
    }
}
