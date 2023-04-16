using UnityEngine;

public class LeverInteraction : Interactible
{
    public Animator leverAnimator;
    public Animator doorAnimator;

    private void Awake()
    {
        leverAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interactiong");
            leverAnimator.SetBool("isActivated", true);
            doorAnimator.SetBool("isOpen", true);
        }
    }
}
