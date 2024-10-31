using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameStarted = false;
    public float reloadSpeed;

    public GameObject player;

    public int lives = 3;
    int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject spawner;

    private void Awake()
    {
        instance = this;
        livesText.text = "Lives: " + lives;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gameUI.SetActive(true);
        spawner.SetActive(true);
    }

    public void GameOver()
    {
        player.SetActive(false);

        Invoke("ReloadLevel", reloadSpeed);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateLives()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            lives--;
            livesText.text = "Lives: " + lives;

        }
    }

    public void UpdateScores()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exitting...");
    }
}
