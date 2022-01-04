using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = 30;
    private float bottomLimit = -5;

    // Update is called once per frame
    void Update()
    {
        // Destroys prefab if prefab is out of bounds

        if (transform.position.x < -leftLimit || transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        } 
    }
}
