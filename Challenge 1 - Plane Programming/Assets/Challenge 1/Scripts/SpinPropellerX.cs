using UnityEngine;

public class SpinPropellerX : MonoBehaviour
{
    private float propellerSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.forward * propellerSpeed);
    }
}
