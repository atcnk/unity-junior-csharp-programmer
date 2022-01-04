using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed = 40.0f;

    void Update()
    {
        // Moves prefabs forward 

        transform.Translate(Vector3.forward * verticalSpeed * Time.deltaTime);
    }
}
