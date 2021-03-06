using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string name;
    public string description;
    public int price;
    public int level;
    public Sprite image;
}
