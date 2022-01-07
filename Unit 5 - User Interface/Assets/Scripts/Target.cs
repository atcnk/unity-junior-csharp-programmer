using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    private Rigidbody targetRB;
    private GameManager gameManagerScript;

    private float ySpawnPos = -2;
    private float xRange = 4;
    private float minSpeed = 12f;
    private float maxSpeed = 16f;
    private float maxTorque = 10;

    private void Start()
    {
        ThrowTarget();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();    
    }

    private void OnMouseDown()
    {
        // Destroys the object and instantiates a particle

        if (gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            gameManagerScript.UpdateScore(pointValue);
            Instantiate(explosionParticle, this.transform.position, explosionParticle.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (!this.gameObject.CompareTag("Bad"))
        {
            gameManagerScript.GameOver();
        }
    }

    private void ThrowTarget()
    {
        // Throws an object (bad or good) up

        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
