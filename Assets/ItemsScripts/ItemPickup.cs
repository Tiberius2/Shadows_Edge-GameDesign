using UnityEngine;

public class ItemPickup : Interactible
{
    public Item item;

    private void Awake()
    {
        radius = 0.4f;
    }

    public override void Interact()
    {
        PickItem();
    }

    private void PickItem()
    {
        Debug.Log("Picking up : " + item.name);
        // Add picked item to inventory
        bool wasPickedUp = Inventory.Instance.Add(item);
        if(wasPickedUp)
            Destroy(gameObject);
    }
}
