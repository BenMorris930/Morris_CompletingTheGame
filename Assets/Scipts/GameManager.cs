using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    private int score = 0;
    public bool isGameRunning = false;
    public GameObject titleScreen;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(float difficultyValue)
    {
        isGameRunning = true;
        spawnRate = 2 / difficultyValue;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(TargetSpawner());
        UpdateScore(0);
    }
    IEnumerator TargetSpawner()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnRate);
            int targetIndex = Random.Range(0, targets.Count);
            Instantiate(targets[targetIndex]);
        }
    }

    public void UpdateScore(int delta)
    {
        if (isGameRunning)
        {
            score += delta;
            if (score < 0) score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameRunning = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
