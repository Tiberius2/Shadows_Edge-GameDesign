using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimatorManager animatorManager;
    PlayerLocomotion playerLocomotion;
    
    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool shift_input;
    public bool jump_input;


    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            playerControls.PlayerActions.Shift.performed += i => shift_input = true;
            playerControls.PlayerActions.Shift.canceled += i => shift_input = false;
            playerControls.PlayerActions.Jump.performed += i => jump_input = true;
            /*playerControls.PlayerActions.Jump.canceled += i => jump_input = false;*/
        }
        playerControls.Enable();

    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        //HandleJumpInput();
        HandleSprintingInput();
        HandleJumpInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (shift_input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        { 
            playerLocomotion.isSprinting = false; 
        }
    }

    private void HandleJumpInput()
    {
        if(jump_input == true)
        {
            jump_input = false;
            playerLocomotion.HandleJumping();
        }
    }
}
