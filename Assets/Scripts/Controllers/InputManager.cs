using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    #region Singleton

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one instance of inventory found!");
            return;
        }

        Instance = this;

        InitialSetup();
    }

    #endregion

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

    public bool attack_input;
    private float cooldown = 1.0f;

    private bool canAttack = true;
    private bool canInteract = true;


    private void InitialSetup()
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
        if (!attack_input)
        {
            HandleMovementInput();
            //HandleJumpInput();
            HandleSprintingInput();
            HandleJumpInput();
        }

        HandleAttack();
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

    private void HandleAttack()
    {
        if (jump_input)
            return;
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            canAttack = false;
            WaitForTimeThenExecute.ExecuteAfterDelay(cooldown, ResetCooldown);

            moveAmount = 0;
            verticalInput = 0;
            horizontalInput = 0;
            verticalInput = 0;
            cameraInputX = 0;
            cameraInputY = 0;
            attack_input = true;
            animatorManager.animator.SetTrigger("Attack");
            StartCoroutine(ResetAttackInput(1.15f)); // replace 0.5f with the desired delay time
        }
    }

    public bool IsAttacking()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            return true;
        }

        return false;
    }

    public bool IsInteracting()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            canInteract = false;

            WaitForTimeThenExecute.ExecuteAfterDelay(1.5f, ResetInteractCooldown);

            return true;
        }

        return false;
    }

    private void ResetInteractCooldown()
    {
        canInteract = true;
    }

    private void ResetCooldown()
    {
        canAttack = true;
    }

    private IEnumerator ResetAttackInput(float delay)
    {
        yield return new WaitForSeconds(delay);
        attack_input = false;
    }
}
