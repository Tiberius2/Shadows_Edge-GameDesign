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

    private readonly Dictionary<Item, int> items = new();


    public bool Add(Item item, int count = 1)
    {
        if (!item.defaultItem)
        {
            bool itemExistsInInventory = items.ContainsKey(item);

            if (item.canBeStacked && itemExistsInInventory)
            {
                // Update item count
                items[item] += count;

                InventoryItemsChanged();

                return true;
            }

            bool noSpaceInInventory = items.Count >= space;

            if (noSpaceInInventory)
            {
                Debug.Log("Not enough room");

                return false;
            }

            items.Add(item, count);

            InventoryItemsChanged();

            return true;
        }

        return true;
    }

    public void Remove(Item item, int count = 1)
    {
        bool itemExistsInInventory = items.ContainsKey(item);

        if (itemExistsInInventory)
        {
            items[item] -= count;

            if (items[item] <= 0)
            {
                items.Remove(item);

                InventoryItemsChanged();
            }
        }
    }

    //public Item Get(int index)
    //{
    //    return items[index];
    //}
    public Dictionary<Item, int> GetItems()
    {
        return items;
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
