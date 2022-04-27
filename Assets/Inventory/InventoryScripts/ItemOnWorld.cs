using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Inventory wordList;

    public GameObject prompt;//��Eʰȡ
    public GameObject pickobject;//Ҫʰȡ������

    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Show(prompt);
            if (Input.GetKeyDown(KeyCode.E))
            {
                AddNewItem();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Hide(prompt);
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        {
            //����ͼ���ռ�
            if(thisItem.isword)
            {
                if(!wordList.itemList.Contains(thisItem))
                {
                    wordList.itemList.Add(thisItem);
                }
            }
            //��Ʒ�ռ����������֣�
            //playerInventory.itemList.Add(thisItem);
            for(int i=0; i<playerInventory.itemList.Count;i++)
            {
                if(playerInventory.itemList[i] == null)
                {
                    playerInventory.itemList[i] = thisItem;
                    break; 
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;
        }

        InventroyManager.RefreshItem(); 
    }

    public void Show(GameObject prompt)
    {
        prompt.SetActive(true);
    }
    public void Hide(GameObject prompt)
    {
        prompt.SetActive(false);
    }
}
