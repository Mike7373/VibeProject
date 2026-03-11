using System;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private CharacterData characterData;

    private Character character;
    private Vector3 playerDirection = Vector3.zero;
    private PlayerController playerController;
    private bool isPlayer = false;
    private Rigidbody rb;

    private static CharacterComponent player;
    private Action onPlayerCharacterChanged;

    private void Awake()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            rb = rigidbody;
        else
            Debug.LogError("There is no rigidbody attached to this GameObject");

        if (TryGetComponent<PlayerController>(out PlayerController p))
        {
            playerController = p;
            player = this;
            isPlayer = true;
        }
    }

    private void Start()
    {
        CheckPlayerController();
        character = new Character(characterData);
    }

    private void OnEnable()
    {
        if (isPlayer)
        {
            playerController.playerMoved += UpdateMoveDirection;
            onPlayerCharacterChanged += CheckPlayerController;
        }
    }

    private void OnDisable()
    {
        playerController.playerMoved -= UpdateMoveDirection;
        onPlayerCharacterChanged -= CheckPlayerController;
    }


    private void Update()
    {
        TryMovePlayer();
    }

    private void UpdateMoveDirection(Vector3 direction)
    {
        playerDirection = direction * character.Speed;
        Debug.Log($"[CharacterComponent] {direction}");
    }

    private void CheckPlayerController()
    {
        if (player == this)
        {
            isPlayer = true;
            return;
        }
        isPlayer = false;
    }

    private void TryMovePlayer()
    {
        if (isPlayer)
        {
            rb.linearVelocity = playerDirection;
            Debug.Log($"[CharacterComponent] Linear velocity: {playerDirection}");
        }
    }
}
