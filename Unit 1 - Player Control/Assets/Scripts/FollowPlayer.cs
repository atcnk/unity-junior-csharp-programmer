using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject vehicleGO;

    Vector3 cameraOffset = new Vector3(0, 5.08f, -7.64f); 

    void LateUpdate()
    {
        // Moves the camera based on vehicle's position and the offset value
        transform.position = vehicleGO.transform.position + cameraOffset;
    }
}
