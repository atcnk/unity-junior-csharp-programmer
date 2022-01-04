using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject foodPrefab;

    private float horizontalInput;
    private float playerSpeed = 35.0f;
    private float boundRange = 15.0f;

    void Update()
    {
        CheckPlayerBounds();

        LaunchFood();

        MovePlayer();
    }

    private void LaunchFood()
    {
        // Launches a food when user presses the space key

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(foodPrefab, this.transform.position, foodPrefab.transform.rotation);
        }
    }

    private void CheckPlayerBounds()
    {
        // Keeps the player in bounds

        if (transform.position.x < -boundRange)
        {
            transform.position = new Vector3(-boundRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundRange)
        {
            transform.position = new Vector3(boundRange, transform.position.y, transform.position.z);
        }
    }

    private void MovePlayer()
    {
        // Gets horizontal input and moves player based on this input

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * playerSpeed * Time.deltaTime);
    }
}
