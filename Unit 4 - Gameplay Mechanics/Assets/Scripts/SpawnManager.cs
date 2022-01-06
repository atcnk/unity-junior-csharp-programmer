using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    private int enemyCount = 0;
    private int waveNumber = 1;
    private float spawnRange = 9f;

    private void Start()
    {
        SpawnEnemy(waveNumber);
        SpawnPowerup();
    }

    private void Update()
    {
        CheckEnemy();
    }

    private void CheckEnemy()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        if (enemyCount == 0)
        {
            waveNumber++;

            SpawnPowerup();
            SpawnEnemy(waveNumber);
        }
    }

    private void SpawnEnemy(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateRandomPosition()
    {
        // Returns random Vector3 position 
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPositionX, 0, spawnPositionZ);        
    }
}