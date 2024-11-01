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

    Vector3 orginalCamPos;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject spawner;
    public GameObject backgroundParticle;


    private void Awake()
    {
        instance = this;
        livesText.text = "Lives: " + lives;
    }

    private void Start()
    {
        orginalCamPos = Camera.main.transform.position;
    }

    public void StartGame()
    {
        gameStarted = true;

        menuUI.SetActive(false);
        gameUI.SetActive(true);
        spawner.SetActive(true);
        backgroundParticle.SetActive(true);

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

    public void Shake()
    {
        StartCoroutine(CameraShake());
    }

    IEnumerator CameraShake()
    {
        for(int i = 0; i < 5; i++)
        {
            Vector2 randomPos = Random.insideUnitCircle * 0.5f;

            Camera.main.transform.position = new Vector3(randomPos.x, randomPos.y, orginalCamPos.z);
            yield return null;
        }

        Camera.main.transform.position = orginalCamPos;
    }
}
