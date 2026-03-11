using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private PlayerBindings _playerInput;


    private void Awake()
    {
        _playerInput = new();
    }
    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Player.Move.canceled += OnMove;
        _playerInput.Player.Move.canceled += OnMove;
    }
    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Player.Move.canceled -= OnMove;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void Update()
    {

    }

    private void OnMove(InputAction.CallbackContext context)
    {

        Move(context.ReadValue<Vector3>(), 5f);
    }

    private bool Move(Vector3 direction, float speed)
    {
        transform.position += direction * speed * Time.deltaTime;
        return true;
    }
}
