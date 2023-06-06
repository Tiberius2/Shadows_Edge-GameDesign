using UnityEngine;

public class Interactible : MonoBehaviour
{
    public float radius = 2.8f;

    private bool canInteract = false;

    public virtual void Interact(){}

    public void Start()
    {
        SphereCollider collider = gameObject.AddComponent<SphereCollider>();
        collider.isTrigger = true;
        collider.radius = radius;
    }

    private void Update()
    {
        if (canInteract)
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
