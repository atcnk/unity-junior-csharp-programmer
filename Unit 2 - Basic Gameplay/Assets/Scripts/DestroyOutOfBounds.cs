using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float foodBound = 20.0f;
    private float animalBound = -7.0f;

    void Update()
    {
        CheckBounds();
    }

    private void CheckBounds()
    {
        // Destroys prefab if prefab is out of bounds
        // If the prefab is an animal, it also logs 'game over'

        if (transform.position.z > foodBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < animalBound)
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
        }
    }
}
