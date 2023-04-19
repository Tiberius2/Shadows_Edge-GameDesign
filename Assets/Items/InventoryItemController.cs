using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{

    Item item;

    public Button RemoveButton;
    public void RemoveItem()
    {
        Inventory.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Armor:
                PlayerStats.Instance.IncreaseArmor(item.value);
                break;
            case Item.ItemType.Weapon:
                PlayerStats.Instance.IncreaseDamage(item.value);
                break;
        }
        RemoveItem();

    }
}

