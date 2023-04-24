using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory Instance;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }

        Instance = this;
    }

    #endregion

    public delegate void OnItemChanged();

    public OnItemChanged OnItemChangedCallback;

    private readonly int space = 20; 

    private readonly List<Item> items = new();


    public bool Add(Item item)
    {
        if (!item.defaultItem)
        {
            bool itemExistsInInventory = items.Contains(item);
            Debug.Log("Item exists: " + itemExistsInInventory);

            if (item.canBeStacked && itemExistsInInventory)
            {
                // Update item count
                Item itemInInventory = items.Find(i => i.Equals(item));
                itemInInventory.count++;

                InventoryItemsChanged();

                return true;
            }

            bool noSpaceInInventory = items.Count >= space;

            if (noSpaceInInventory)
            {
                Debug.Log("Not enough room");

                return false;
            }

            items.Add(item);

            InventoryItemsChanged();

            return true;
        }

        return true;
    }

    public void Remove(Item item)
    {
        bool itemExistsInInventory = items.Contains(item);

        if (itemExistsInInventory)
        {
            Item itemInInventory = items.Find(i => i.Equals(item));
            itemInInventory.count--;

            if (itemInInventory.count <= 0)
            {
                items.Remove(item);

                InventoryItemsChanged();
            }
        }
    }

    public Item Get(int index)
    {
        return items[index];
    }

    public int GetCount() 
    { 
        return items.Count; 
    }

    private void InventoryItemsChanged()
    {
        OnItemChangedCallback?.Invoke();
    }
}
