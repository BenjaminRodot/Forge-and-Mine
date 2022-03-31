using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public string typeOfWeapon;
    public Item itemNeededToForge;
    public int nbItemNeededToForge;
}