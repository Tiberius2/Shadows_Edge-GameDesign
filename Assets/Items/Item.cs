using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public int value;
    public Sprite icon;

    public GameObject model = null;

    public ItemType itemType;

    public enum ItemType
    {
        Potion,
        Armor,
        Weapon,
        Shield,
    }
}
