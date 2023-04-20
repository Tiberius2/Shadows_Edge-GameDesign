public class ItemPickup : Interactible
{
    public Item Item;

    private void Awake()
    {
        radius = 0.4f;
    }

    public override void Interact()
    {
        base.Interact();
        PickItem();
    }

    private void PickItem()
    {
        // Add picked item to inventory
        bool wasPickedUp = Inventory.Instance.Add(Item);

        if(wasPickedUp)
            Destroy(gameObject);
    }
}
