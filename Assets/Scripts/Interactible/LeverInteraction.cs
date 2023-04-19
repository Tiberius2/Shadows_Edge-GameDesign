using UnityEngine;

public class LeverInteraction : Interactible
{
    public Animator leverAnimator;
    public Animator doorAnimator;

    private bool isActivated = false;
    private bool isOpen = false;

    private void Awake()
    {
        leverAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (InputManager.Instance.IsInteracting())
        {
            isActivated = !isActivated; // toggle the state of the lever
            leverAnimator.SetBool("isActivated", isActivated);

            isOpen = !isOpen; // toggle the state of the door
            doorAnimator.SetBool("isOpen", isOpen);
        }
    }
}