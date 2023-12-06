using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text hiScoreText;
    [SerializeField] int startLives = 5;
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject endMessage;
    [SerializeField] GameObject winMessage;
    [SerializeField] GameObject restartButton;
    int currentLives;
    int currentScore;
    int currentHiScore;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType<GameSession>().Length;
        if(instanceCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        currentLives = startLives;

        restartButton.GetComponent<Button>().onClick.AddListener(Restart);

        currentHiScore = PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");

        if(balls.Length <= 0)
        {
            DecreaseLives();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().BallReset();
        }

        var blocks = GameObject.FindGameObjectsWithTag("Block");

        if(blocks.Length == 0)
        {
            Win();
        }

        livesText.text = currentLives.ToString();
        scoreText.text = currentScore.ToString();
        hiScoreText.text = currentHiScore.ToString();
    }

    public void IncreaseScore(int value)
    {
        currentScore += value;
    }

    public void DecreaseLives()
    {
        currentLives--;

        if(currentLives <= 0)
        {
            GameOver();
        }
    }

    private void Win()
    {
        var sceneNumber = SceneManager.sceneCountInBuildSettings;

        var currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentBuildIndex == sceneNumber - 1)
        {
            Pause();
            endScreen.SetActive(true);
            restartButton.SetActive(true);
            winMessage.SetActive(true);

            SetHiScore();
        }
        else
        {
            SceneManager.LoadScene(currentBuildIndex + 1);
        }
    }
    private void GameOver()
    {
        endScreen.SetActive(true);
        endMessage.SetActive(true);
        restartButton.SetActive(true);

        SetHiScore();

        Pause();
    }

    private void Restart()
    {
        ScoreReset();

        SceneReset();

        Scene1Reset();
    }

    private void SceneReset()
    {
        endScreen.SetActive(false);
        endMessage.SetActive(false);
        winMessage.SetActive(false);
        restartButton.SetActive(false);

        UnPause();
    }

    private void ScoreReset()
    {
        currentLives = startLives;
        currentScore = 0;
    }

    private void Scene1Reset()
    {
        SceneManager.LoadScene(1);
    }

    private void SetHiScore()
    {
        if(currentScore > currentHiScore)
        {
            currentHiScore = currentScore;
            PlayerPrefs.SetInt("highscore", currentHiScore);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void UnPause()
    {
        Time.timeScale = 1f;
    }
}
