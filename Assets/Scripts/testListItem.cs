using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testListItem : MonoBehaviour
{

    public List<Item> list;

    public Item GetItem(string itemName)
    {
        foreach(Item item in list)
        {
            if (item.name == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
