using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 60f;

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
