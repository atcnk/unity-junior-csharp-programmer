using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject titleScreenGO;

    private float spawnRate = 1.0f;
    private int gameScore;

    public bool isGameActive;

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    private IEnumerator SpawnTarget()
    {
        // Countinues to instantiate objects if game is still active
        
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        gameScore += scoreToAdd;
        scoreText.text = "Score:" + gameScore;
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        titleScreenGO.SetActive(false);
        isGameActive = true;

        UpdateScore(0);
        StartCoroutine(SpawnTarget());
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
