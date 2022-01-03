using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float planeSpeed = 20.0f;
    private float rotationSpeed = 30.0f;
    private float verticalInput;

    void Update()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * planeSpeed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed * verticalInput);
    }
}
