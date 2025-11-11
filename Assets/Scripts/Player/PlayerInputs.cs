using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public Action<Vector2> OnMoveChange;
    public Action OnJumpPerformed;

    private Vector2 moveInput;
    private void Awake()
    {
        inputs = new();
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.started += OnMove;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Move.canceled += OnMove;

        inputs.Player.Jump.performed += OnJump;

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        OnMoveChange?.Invoke(moveInput);
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    void Start()
    {
        
    }
    public Vector2 MoveInput => moveInput;
}
