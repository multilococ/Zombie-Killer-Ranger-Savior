using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    private InputActions _inputActions;

    private Vector2 screenPointPosition;

    public event Action OnShootPressed;

    public Vector2 ScreenPointPosition => screenPointPosition;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _inputActions.Weapon—ontrol.Shoot.performed += ThrowShootEvent;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    public void Update()
    {
        screenPointPosition = _inputActions.Weapon—ontrol.Aiming.ReadValue<Vector2>();
    }

    private void ThrowShootEvent(InputAction.CallbackContext obj)
    {
        OnShootPressed?.Invoke();
    }
}
