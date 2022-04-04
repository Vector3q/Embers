using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventroyManager : MonoBehaviour
{
    static InventroyManager instance;

    public Inventory bag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfo;
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    public static void CreateNewItem(Item item)
    {
        Debug.Log(1);
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        //成为Grid的子集
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }
}  
