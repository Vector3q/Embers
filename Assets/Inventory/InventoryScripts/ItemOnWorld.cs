using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Inventory wordList;

    public GameObject prompt;//按E拾取

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
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
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
            //文字图鉴收集
            if(thisItem.isword)
            {
                if (!wordList.itemList.Contains(thisItem))
                {
                    wordList.itemList.Add(thisItem);
                }
                else if (wordList.itemList.Contains(thisItem))
                    return;
            }
            //物品收集（包括文字）
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
            if(!thisItem.isword)
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
