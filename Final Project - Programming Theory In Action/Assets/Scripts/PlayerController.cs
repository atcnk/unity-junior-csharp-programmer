using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bulletPrefab;
    [SerializeField]
    private Transform barrelTransform;

    private float angleOffset = 90f;
    private float bulletSpeed = 10f;
    private void Start()
    {
        MainManager.Instance.StartSpawn();
    }
    private void Update()
    {
        // ABSTRACTION
        Rotate();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Rotate()
    {
        // Calculate the angle by mouse position and change player's direction

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - angleOffset;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void Fire()
    {
        Rigidbody2D bulletRB;

        bulletRB = Instantiate(bulletPrefab, barrelTransform.position, this.transform.rotation);
        bulletRB.velocity = this.transform.TransformDirection(Vector3.up * bulletSpeed);
    }
}