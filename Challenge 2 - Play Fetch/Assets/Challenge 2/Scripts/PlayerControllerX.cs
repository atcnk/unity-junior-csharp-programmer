using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]
    private GameObject dogPrefab;

    private bool canSpawn = true;

    void Update()
    {
        // Spawns dog when user presses the space key if dog can spawn
        // After dog spawns, prevents that dog can spawn again for 0.7 seconds

        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            canSpawn = false;
            Invoke("LetDogSpawn", 0.7f);
        }
    }

    void LetDogSpawn()
    {
        // Sets dog can spawn true
        canSpawn = true;
    }
}
