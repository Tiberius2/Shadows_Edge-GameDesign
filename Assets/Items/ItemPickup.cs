using UnityEngine;

public class ItemPickup : Interactible
{
    public Item Item;

    public ItemPickup()
    {
        radius = 0.1f;
    }

    public override void Interact()
    {
        PickItem();
    }

    private void PickItem()
    {
        // Add picked item to inventory
        Inventory.Instance.Add(Item);

        Debug.Log("Item " +  Item.name + " added to inventory"); // TODO: delete this

        Destroy(gameObject);
    }
}
