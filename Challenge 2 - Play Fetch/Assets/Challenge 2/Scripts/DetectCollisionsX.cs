using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Destroys ball if dog and ball hit each other

        Destroy(gameObject);
    }
}
