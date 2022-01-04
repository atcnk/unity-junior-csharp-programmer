using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] animalPrefabs;

    private float spawnRangeX = 15.0f;
    private float spawnPosZ = 13.7f;

    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        // 2 seconds after the game starts, it calls SpawnRandomAnimal every 1.5 seconds 
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        // Produces random index and xPosition for animal spawn

        int randomAnimalIndex = Random.Range(0, animalPrefabs.Length);
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosZ);

        // Spawns random animal at random position
        Instantiate(animalPrefabs[randomAnimalIndex], spawnPos, animalPrefabs[randomAnimalIndex].transform.rotation);
    }
}
