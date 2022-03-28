using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profil : MonoBehaviour
{
    public List<Inventory> inventories = new List<Inventory>{Inventory.instance};
    public List<string> pseudos = new List<string>{"Kiau"};

    public void Add(string pseudo, Inventory inventory)
    {
        pseudos.Add(pseudo);
        inventories.Add(inventory);
    }

}
