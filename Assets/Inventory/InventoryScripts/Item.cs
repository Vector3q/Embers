using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item",menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public int itemHeld;
    [TextArea]
    public string itemInfo;

    public bool isInteraction;
    public bool isword;
}
