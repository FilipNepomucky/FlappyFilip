using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapPower = 11.5f;
    public GameManagerScript gameManager;
    public bool playerAlive = true;
    [SerializeField] private AudioSource deathSound;

    void Awake()
    {
        Time.timeScale = 1;

        if(PlayerPrefs.HasKey("HighScore") == false)
        {
            gameManager.highScore = 0;
            PlayerPrefs.SetInt("HighScore", gameManager.highScore);
            gameManager.highScoreText.text = "High score: " + gameManager.highScore.ToString();
        }
        else
        {
            gameManager.LoadHighScore();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerAlive)
        {
            myRigidBody.velocity = Vector2.up * flapPower;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.OpenMenuScene();
        }

        if (playerAlive == false)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                gameManager.RestartGame();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0;
        deathSound.Play();
        gameManager.GameOver();
        playerAlive = false;
    }
}
