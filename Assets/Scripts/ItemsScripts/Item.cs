using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";

    public Sprite icon = null;

    public GameObject model = null;

    public bool defaultItem = false;

    public bool canBeStacked = false;

    public float pickupRadius = 0.8f;

    private int amount;


    private void Awake()
    {
        amount = 1;
    }

    public virtual void Use()
    {
        Debug.Log("Using" + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.Instance.Remove(this);
    }

    public int GetAmount()
    {
        return amount;
    }

    public void AddAmount(int amount = 1)
    {
        this.amount += amount;
    }

    public void SubstractAmount(int amount = 1)
    {
        this.amount -= amount;
    }
}
