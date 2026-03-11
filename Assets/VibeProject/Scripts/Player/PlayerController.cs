using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Character))]
public class PlayerController : MonoBehaviour
{
    private PlayerBindings _playerInput;
    public Action<Vector3> playerMoved;

    private void Awake()
    {
        _playerInput = new();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnMoveInput;
        _playerInput.Player.Move.canceled += OnMoveInput;
    }
    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnMoveInput;
        _playerInput.Player.Move.canceled -= OnMoveInput;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        playerMoved?.Invoke(context.ReadValue<Vector3>());
    }
}
