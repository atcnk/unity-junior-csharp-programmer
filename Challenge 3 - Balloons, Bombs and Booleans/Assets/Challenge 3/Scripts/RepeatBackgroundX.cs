using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    private PlayerControllerX playerControllerXScript;

    private void Start()
    {
        playerControllerXScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        startPos = transform.position; // Establish the default starting position 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (transform.position.x < startPos.x - repeatWidth && !playerControllerXScript.gameOver)
        {
            transform.position = startPos;
        }
    }
}


