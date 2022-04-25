using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSpecial : MonoBehaviour
{
    public Item word_fire;
    public Item word_seed;
    public Item word_autumn;


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
    //��������ͼ��
    public Inventory wordList;

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
        if(leftImage.sprite == word_seed.itemImage && rightImage.sprite == word_fire.itemImage)
        {
            if (!wordList.itemList.Contains(word_autumn))
            {
                successImage.gameObject.SetActive(true);
                successImage.sprite = word_autumn.itemImage;
            }
        }
    }
}
