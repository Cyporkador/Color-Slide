using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenuController : MonoBehaviour
{
    public GameObject scoreUI;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public AudioSource music;
    public AudioSource sound;
    public bool muted;

    public static bool gameOver;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isPaused = false;
        muted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                isPaused = true;
            }
            else
            {
                Resume();
            }
            
        }
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
            scoreUI.SetActive(false);
            scoreText.text = "Score : " + (ScoreHandler.score + "");
            highscoreText.text = "Highscore : " + (ScoreHandler.highscore + "");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (muted)
            {
                muted = false;
                music.enabled = false;
                sound.enabled = false;
            } else
            {
                muted = true;
                music.enabled = true;
                sound.enabled = true;
            }
        } else if (Input.GetKeyDown(KeyCode.Space) && gameOver)
        {
            Replay();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Menu()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        scoreUI.SetActive(true);
        isPaused = false;
        gameOver = false;
        ScoreHandler.score = 0;
        SceneManager.LoadScene("Menu");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        gameOverMenu.SetActive(false);
        scoreUI.SetActive(true);
        gameOver = false;
        ScoreHandler.score = 0;
        SceneManager.LoadScene("Game");
    }
}
