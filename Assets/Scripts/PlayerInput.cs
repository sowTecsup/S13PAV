using NUnit.Framework.Constraints;
using Sirenix.OdinInspector.Editor.Drawers;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public InputSystem_Actions inputs;
    public Action<Vector2> OnMoveChange;
    public Action OnJumpPerformed;

    private Vector2 moveInput;

    public Action OnAttackPerformed;
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

        inputs.Player.Attack.performed += OnAttack;

    }

    private void OnJump(InputAction.CallbackContext context)
    {
        OnJumpPerformed?.Invoke();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("Move Input: " + moveInput);
        OnMoveChange?.Invoke(moveInput);
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackPerformed?.Invoke();
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
