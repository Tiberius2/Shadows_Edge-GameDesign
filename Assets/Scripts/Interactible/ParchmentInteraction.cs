using UnityEngine;

public class ParchmentInteraction : MonoBehaviour
{
    public float radius = 2.5f;

    public GameObject parchment;

    private GameObject parchmentInstance;

    private bool isOpen = false;

    private bool canInteract = false;

    private bool fadeIn = false;

    private bool fadeOut = false;

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

        HandleFade();
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

            fadeOut = true;
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isOpen)
            {
                OpenParchment();
                fadeOut = false;
            }
            else
            {
                CloseParchment();
            }
        }
    }

    private void OpenParchment()
    {
        if (parchment != null && !fadeIn)
        {
            parchmentInstance = Instantiate(parchment);

            CanvasGroup canvasGroup = parchmentInstance.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;

            fadeIn = true;
        }
    }

    private void CloseParchment()
    {
        if (isOpen)
        {
            fadeOut = true;
        }
    }

    private void HandleFade()
    {
        if (fadeIn && !isOpen)
        {
            FadeIn();
        }

        if (fadeOut && isOpen)
        {
            FadeOut();
        }
    }

    private void FadeIn()
    {
        if (parchmentInstance != null)
        {
            CanvasGroup canvasGroup = parchmentInstance.GetComponent<CanvasGroup>();

            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += Time.deltaTime;

                if (canvasGroup.alpha >= 1)
                {
                    isOpen = true;
                    fadeIn = false;
                }
            }
        }
    }

    private void FadeOut()
    {
        if (parchmentInstance != null)
        {
            CanvasGroup canvasGroup = parchmentInstance.GetComponent<CanvasGroup>();

            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= Time.deltaTime;

                if (canvasGroup.alpha <= 0)
                {
                    fadeOut = false;
                    isOpen = false;

                    if (parchmentInstance != null)
                    {
                        Destroy(parchmentInstance);
                    }
                }
            }
        }
    }
}
