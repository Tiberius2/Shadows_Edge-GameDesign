using UnityEngine;

public class Droppable : Interactible
{
    public Item Item;

    private int hp = 2;

    public Droppable()
    {
        radius = 0.2f;
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Current hp: " + hp);
            // TODO: add waiting time between attacks

            if (--hp <= 0)
            {
                CreateItem();

                Destroy(gameObject);
            }
        }
    }

    private void CreateItem()
    {
        // Create the object that can be picked after the current droppable object is destroyed
        GameObject pickableItem = Instantiate(Item.model);
        pickableItem.name = Item.name;
        pickableItem.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        ItemPickup itemPickup = pickableItem.AddComponent<ItemPickup>();
        itemPickup.Item = Item;
    }
}
