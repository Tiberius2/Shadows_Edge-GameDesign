using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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

    public Transform itemContent;
    public GameObject inventoryItem;

    public Toggle EnableRemove;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public InventoryItemController[] InventoryItems;

    public bool Add(Item item)
    {

        if(items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }
        items.Add(item);
        if(OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }

    public void ListItems()
    {
        //Clean content before open
        foreach(Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in items)
        {
           GameObject obj = Instantiate(inventoryItem, itemContent);
           var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
           var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

           itemName.text = item.name;
           itemIcon.sprite = item.icon;

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }
        SetInventoryItems();
    }

    public void EnebleItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach(Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in itemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }

        
    }

    public void SetInventoryItems()
    {
        InventoryItems = itemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < items.Count; i++)
        {
            InventoryItems[i].AddItem(items[i]);

        }
    }
}
