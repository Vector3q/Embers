using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    public Inventory wordList;

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
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if(!playerInventory.itemList.Contains(thisItem))
        {
            //文字图鉴收集
            if(thisItem.isword)
            {
                if(!wordList.itemList.Contains(thisItem))
                {
                    wordList.itemList.Add(thisItem);
                }
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
            thisItem.itemHeld += 1;
        }

        InventroyManager.RefreshItem(); 
    }
}
