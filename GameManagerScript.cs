using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class GameManagerScript : MonoBehaviour
{
    public int playerScore = 0;
    public int highScore = 0;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highScoreText;
    public GameObject gameOverScreen;
    public GameObject clouds;

    private void Awake()
    {
        ControlClouds();
    }


    [ContextMenu("Open Menu Scene")]
    public void OpenMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        if(playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "High score: " + highScore.ToString();
        }
    }

    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Trigger Game Over")]
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void ControlClouds()
    {
        clouds.SetActive(MenuScript.cloudsOn);
        Debug.Log("Clouds active: " + MenuScript.cloudsOn.ToString());
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High score: " + highScore.ToString();
    }
}
