using UnityEngine;
using TMPro;

public class MainManager : MonoBehaviour
{
    // ENCAPSULATION
    public static MainManager Instance { get; private set; }
    
    [SerializeField]
    private Rigidbody2D[] enemyPrefabs;

    private float maxBound = 4.44f;
    private float minBound = 2f;
    private float inTimeSec = 1f;
    private float repeatRate = 0.5f;
    private int pointsPerKill = 10;

    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private bool _gameOver;
    // ENCAPSULATION
    public bool GameOver { get => _gameOver; set => _gameOver = value; }

    private void Awake()
    {
        // SINGLETON
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void DamagePlayer(int damage)
    {
        Player.Instance.Health -= damage;

        UpdateHealth();
        CheckPlayerAlive();
    }

    private void CheckPlayerAlive()
    {
        if (Player.Instance.Health <= 0 && !GameOver)
        {
            FinishGame();
        }
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + Player.Instance.Health.ToString();
    }

    public void UpdateScore()
    {
        Player.Instance.Score += pointsPerKill;
        scoreText.text = "Score: " + Player.Instance.Score.ToString();
    }

    private void FinishGame()
    {
        GameOver = true;
        gameOverText.gameObject.SetActive(true);

        StopSpawn();
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnEnemies", inTimeSec, repeatRate);
    }

    public void StopSpawn()
    {
        CancelInvoke();
    }

    private void SpawnEnemies()
    {
        Rigidbody2D enemyRB;
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
       
        enemyRB = Instantiate(enemyPrefabs[enemyIndex], GetRandomPosition(), enemyPrefabs[enemyIndex].transform.rotation);
        Vector3 dir = (Vector3.zero - enemyRB.transform.position);
        enemyRB.velocity = this.transform.TransformDirection(dir);
    }

    // ABSTRACTION
    private Vector3 GetRandomPosition()
    {
        float randomX = GetRandomNumber(maxBound);
        float randomY = GetRandomNumber(maxBound);

        return new Vector3(randomX, randomY, 0f);
    }

    private float GetRandomNumber(float range)
    {
        float randomNumber = Random.Range(-range, range);

        if (randomNumber > -minBound && randomNumber < 0)
        {
            randomNumber += -minBound;
            return randomNumber;
        }

        if (randomNumber > 0 && randomNumber < minBound)
        {
            randomNumber += minBound;
            return randomNumber;
        }
        
        return randomNumber;
    }
}
