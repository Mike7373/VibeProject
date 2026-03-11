using System;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

    private Character _character;
    private Vector3 _playerDirection = Vector3.zero;
    private Rigidbody _rb;
    public bool isPlayer;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            _rb = rigidbody;
        else
            Debug.LogError("There is no rigidbody attached to this GameObject");
    }

    private void Start()
    {
        _character = new Character(characterData);
    }



    private void Update()
    {
        TryMovePlayer();
    }

    public void UpdateMoveDirection(Vector3 direction)
    {
        _playerDirection = direction * _character.Speed;
        Debug.Log($"[CharacterComponent] {direction}");
    }

    private void TryMovePlayer()
    {
        if (isPlayer)
        {
            _rb.linearVelocity = _playerDirection;
            Debug.Log($"[CharacterComponent] Linear velocity: {_playerDirection}");
        }
    }
}
