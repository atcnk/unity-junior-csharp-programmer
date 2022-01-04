using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeGO;

    void Update()
    {
        // Looks at the cube always
        this.transform.LookAt(cubeGO.transform);
    }
}
