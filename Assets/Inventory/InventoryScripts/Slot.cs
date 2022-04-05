using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public int slotID;//空格ID 等于 物品ID
    public Item slotItem; 
    public Image slotImage;
    public Text slotNum;
    public string slotInfo;

    public GameObject itemInSlot;
     
    public void ItemOnClicked()
    {
        InventroyManager.updateItemInfo(slotItem.itemInfo);
    }

    public void SetupSlot(Item item)
    {
        if(item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;

    }
}
