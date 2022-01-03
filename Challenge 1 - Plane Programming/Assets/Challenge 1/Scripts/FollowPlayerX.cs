using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject planeGO;

    private Vector3 cameraOffset = new Vector3(30.0f, 0, 0);

    void LateUpdate()
    {
        // Moves the camera based on plane's position and the offset value
        transform.position = planeGO.transform.position + cameraOffset;
    }
}
