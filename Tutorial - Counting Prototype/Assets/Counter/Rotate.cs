using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float rotationValue = 60f;

    private void Start()
    {
        SetRotation();
    }

    private void SetRotation()
    {
        float randomRotation = Random.Range(-rotationValue, rotationValue);

        transform.eulerAngles = new Vector3(randomRotation, 0f, 0f);
    }
}
