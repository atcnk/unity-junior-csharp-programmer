using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Destroys both food and animal if they hit each other

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
