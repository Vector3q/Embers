using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���ֺϳ�
/// </summary>
public class WordSynthesis : MonoBehaviour
{
    static public Item leftword;
    static public Item rightword;
    public Item successword;
    public Image leftImage;
    public Image rightImage;
    public Image successImage;
    private void Update()
    {
        if(leftword != null)
            leftImage.sprite = leftword.itemImage;
    }
    //public void Synthesis_autumn()
    //{
    //    if (DetectSpecial.planeSynthesis.activeSelf == true)
    //    {
    //        if(leftword.itemName == "fire" && rightword.itemName == "seed")
    //        {
    //            leftImage.gameObject.SetActive(false);
    //            rightImage.gameObject.SetActive(false);
    //            successImage.gameObject.SetActive(true);
    //        }
    //    }
    //}
}
