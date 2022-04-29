using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName = "Inventory/New Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();

    public bool isObtainItem(Item item)
    {
        if (itemList.Contains(item))
            return true;
        return false;
    }
    ///// <summary>
    ///// ��ȡ��Ʒ��inventory��
    ///// </summary>
    ///// <param name="item">��ȡ������</param>
    //public void ObtainNewObject_Unlimited(Item item)
    //{
    //    if(item.isword)
    //    {
    //        if (itemList.Contains(item))
    //            return;
    //        else if(!itemList.Contains(item))
    //        {
    //            itemList.Add(item);
    //        }
    //    }
    //}

    //public void ObtainNewObject_Limited(Item item)
    //{
    //    if(item.isword)
    //    {

    //    }
    //}
}
