using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCoinScript : MonoBehaviour
{
    public GameManagerScript gameManager;
    public PlayerScript player;
    public GameObject coin;
    [SerializeField] private AudioSource scoreUpSound; // [SerializeField] means it'll be private but still show up in the Unity editor

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3 && player.playerAlive)
        {
            scoreUpSound.Play();
            coin.GetComponent<CircleCollider2D>().enabled = false;
            gameManager.AddScore(1);
            coin.GetComponent<Renderer>().enabled = false;
        }
    }
}
