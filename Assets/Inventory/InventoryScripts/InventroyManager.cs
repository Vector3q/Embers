using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventroyManager : MonoBehaviour
{
    static InventroyManager instance;

    public Inventory bag;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptyslot;
    public Text itemInfo;

    public List<GameObject> slots = new();
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfo.text = "";
    }

    public static void updateItemInfo(string ItemDescription)
    {
        instance.itemInfo.text = ItemDescription;
    }

    public static void RefreshItem()
    {
        for(int i = 0; i<instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for(int i=0; i<instance.bag.itemList.Count; i++)
        {
            instance.slots.Add(Instantiate(instance.emptyslot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().slotID = i;
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.bag.itemList[i]);     
        }
    }
}  
