using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    public float speed;

    void Update()
    {
        // Moves prefabs forward 

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
