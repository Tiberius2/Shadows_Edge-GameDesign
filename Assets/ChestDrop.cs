using System.Collections;
using UnityEngine;

public class ChestDrop : Interactible
{
    public Item item;
    public Animator chestAnimator;

    private bool isOpen = false;

    private void Awake()
    {
        chestAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (InputManager.Instance.IsInteracting() && !GameState.Instance.IsPaused)
        {
            isOpen = !isOpen; // toggle the state of the door
            chestAnimator.SetBool("isOpen", isOpen);
            WaitForTimeThenExecute.ExecuteAfterDelay(0.8f, HandleSpawn);
        }
    }

    private void HandleSpawn()
    {
        if (item != null)
        {
            CreateItem();
        }
    }

    private void CreateItem()
    {
        // Create the object that can be picked after the current droppable object is destroyed
        GameObject pickableItem = Instantiate(item.model);
        pickableItem.name = item.name;
        pickableItem.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        ItemPickup itemPickup = pickableItem.AddComponent<ItemPickup>();
        itemPickup.item = item;
        itemPickup.radius = item.pickupRadius;
    }

}
