public class ItemPickup : Interactible
{
    public Item Item;

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
        // Add picked item to inventory
        Inventory.Instance.Add(Item);

        Destroy(gameObject);
    }
}
