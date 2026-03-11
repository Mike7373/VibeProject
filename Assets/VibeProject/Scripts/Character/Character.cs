using UnityEngine;

public class Character : MonoBehaviour
{
    //Cambiare
    private float speed = 5;
    private Vector3 playerDirection = Vector3.zero;

    private PlayerController playerController;
    private bool isPlayer = false;

    private void Awake()
    {
        if (TryGetComponent<PlayerController>(out PlayerController p))
        {
            playerController = p;
            isPlayer = true;
        }
    }

    private void OnEnable()
    {
        if (isPlayer)
        {
            playerController.playerMoved += UpdateMoveDirection;
        }
    }

    private void OnDisable()
    {
        playerController.playerMoved -= UpdateMoveDirection;
    }


    private void Update()
    {
        TryMovePlayer();
    }

    private void UpdateMoveDirection(Vector3 direction)
    {
        playerDirection = direction * speed * Time.deltaTime;
    }

    private void TryMovePlayer()
    {
        if (isPlayer)
        {
            transform.position += playerDirection;
        }
    }
}
