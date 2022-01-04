using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float startDelay = 1.0f;

    void Start()
    {
        // 1 second after the game starts, it calls SpawnRandomAnimal
        Invoke("SpawnRandomBall", startDelay);
    }

    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int ballIndex = Random.Range(0, 2);

        // Spawn random ball at random x position at top of play area
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // Generate random spawn interval of balls
        float spawnInterval = Random.Range(0.5f, 2f);
        Invoke("SpawnRandomBall", spawnInterval);
    }

}
