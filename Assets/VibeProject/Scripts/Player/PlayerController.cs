using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterComponent))]
public class PlayerController : MonoBehaviour
{
    private CharacterComponent _charComponent;
    private PlayerBindings _playerInput;

    private void Awake()
    {
        _playerInput = new();
        _charComponent = GetComponent<CharacterComponent>();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnMoveInput;
        _playerInput.Player.Move.canceled += OnMoveInput;
        _charComponent.isPlayer = true;
    }
    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnMoveInput;
        _playerInput.Player.Move.canceled -= OnMoveInput;
        _charComponent.isPlayer = false;
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        _charComponent.UpdateMoveDirection(context.ReadValue<Vector3>());
    }
}
