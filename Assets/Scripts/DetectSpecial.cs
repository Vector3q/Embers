using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSpecial : MonoBehaviour
{
    //�ϳɽ���
    public GameObject planeSynthesis;
    static public bool Detected;
    static int whichone;
    //�ϳɽ�������
    static public Item leftword;
    static public Item rightword;
    public Item successword;
    public Image leftImage;
    public Image rightImage;
    public Image successImage;
    private void Start()
    {
        whichone = 0;
    }
    private void Update()
    {
        if(planeSynthesis.activeSelf)
        {
            Detected = true;
        }
        else
        {
            Detected = false;
        }
    }
    /// <summary>
    /// ����⵽������������Ʒʱ
    /// </summary>
    public void detectSomething()
    {
        if(PlayerController.Selected_Equipment.itemName == "paper")
        {
            planeSynthesis.SetActive(true);
        }
        if(planeSynthesis.activeSelf && PlayerController.Selected_Equipment.isword)
        {
            if(whichone == 0)
            {
                if (PlayerController.Selected_Equipment.itemImage != leftImage.sprite)
                    whichone = 1;
                leftImage.sprite = PlayerController.Selected_Equipment.itemImage;
            }
            else if(whichone == 1)
            {
                if(PlayerController.Selected_Equipment.itemImage != rightImage.sprite)
                    whichone = 0;
                rightImage.sprite = PlayerController.Selected_Equipment.itemImage;
            }
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
