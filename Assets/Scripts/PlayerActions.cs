using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public Vector2 moveValue;
    private InputActions _inputActions;

    void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnStopMove;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext c)
    {
        moveValue = c.ReadValue<Vector2>();
    }

    private void OnStopMove(InputAction.CallbackContext c)
    {
        moveValue.x = 0;
        moveValue.y = 0;
    }
}
