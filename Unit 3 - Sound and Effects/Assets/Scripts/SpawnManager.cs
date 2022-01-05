using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacleGO;

    private PlayerController playerControllerScript;

    private Vector3 spawnPos = new Vector3(25f, 0f, 0f);
    private float startDelay = 2;
    private float repeatRate = 2;

    private void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    private void SpawnObstacles()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstacleGO, spawnPos, obstacleGO.transform.rotation);
        }
    }
}
