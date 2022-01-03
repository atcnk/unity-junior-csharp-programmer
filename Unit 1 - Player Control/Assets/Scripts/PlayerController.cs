using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float vehicleSpeed = 20f;
    private float turnSpeed = 60f;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
		// Gets the user's vertical & horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed * verticalInput);

        // Rotates the car based on horizontal input
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
