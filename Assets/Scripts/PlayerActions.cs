using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public Vector2 moveValue;
    public bool shootValue;
    private InputActions _inputActions;

    void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnStopMove;
        _inputActions.Player.Shoot.performed += OnShoot;
        _inputActions.Player.Shoot.canceled += OnStopShoot;
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

    private void OnShoot(InputAction.CallbackContext c)
    {
        shootValue = true;
    }

    private void OnStopShoot(InputAction.CallbackContext c)
    {
        shootValue = false;
    }
}
