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

    public int space = 20; 

    public List<Item> items = new List<Item>();
    public bool Add(Item item)
    {
        if (!item.defaultItem) {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
        }       
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
