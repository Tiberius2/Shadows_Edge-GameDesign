using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool defaultItem = false;
   
     
    public GameObject model = null;

    public virtual void Use()
    {
        //use the item
        //something might happen
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }
}
