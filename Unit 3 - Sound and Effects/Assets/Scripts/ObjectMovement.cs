using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private PlayerController playerControllerScript;

    private float movementSpeed = 30f;
    private float obstacleBoundX = -15f;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            MoveLeft();
        }

        if (transform.position.x < obstacleBoundX)
        {
            DestroyObstacle();
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    private void DestroyObstacle()
    {
        Destroy(gameObject);
    }
}
