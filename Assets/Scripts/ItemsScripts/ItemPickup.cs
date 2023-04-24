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
        // Add item to inventory if there is space
        bool wasPickedUp = Inventory.Instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(gameObject);
        }
    }
}
