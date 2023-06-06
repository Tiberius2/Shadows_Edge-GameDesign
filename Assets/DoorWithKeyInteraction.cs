using UnityEngine;

public class DoorWithKeyInteraction : Interactible
{
    public Animator doorAnimator;

    private bool isOpen = false;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (InputManager.Instance.IsInteracting() && Inventory.Instance.HasItem("KeyChain"))
        {
            isOpen = !isOpen; // toggle the state of the door
            doorAnimator.SetBool("isOpen", isOpen);
        }
    }
}
