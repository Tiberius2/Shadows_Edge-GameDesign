using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraManager cameraManager;

    public bool isInteracting;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();

    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        inputManager.HandleAllInputs();
    }
    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }


    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();
        isInteracting = animator.GetBool("isInteracting");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerLocomotion.isGrounded);
    }
}
