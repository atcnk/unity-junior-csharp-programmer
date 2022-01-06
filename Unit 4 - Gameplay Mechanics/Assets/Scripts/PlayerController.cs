using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject powerupIndicatorGO;

    private Rigidbody playerRB;
    private GameObject focalGO;

    protected bool hasPowerup = false;
    private float playerSpeed = 5.0f;
    private float powerUpStrength = 15.0f;

    private void Start()
    {
        focalGO = GameObject.Find("Focal Point");
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        powerupIndicatorGO.transform.position = this.transform.position + new Vector3(0, -0.5f, 0);

        Move();
    }

    private void Move()
    {
        // Move player in the direction the camera is facing

        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalGO.transform.forward * playerSpeed * forwardInput);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicatorGO.SetActive(true);
            StartCoroutine(PowerupCountDownRoutine());
        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position);

            enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}