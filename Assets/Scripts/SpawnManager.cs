using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SpawnManager : MonoBehaviour
{
    public int score;    
    public Text scoreText;
    [HideInInspector] public bool isScored;
    public bool a;

    private float spawnLimitXLeft = -6;
    private float spawnLimitXRight = 3;
    
    public GameObject ball;
    public GameOverScreen GameOverScreen;
    void Start()
    {
        transform.position = new Vector2(Random.Range(spawnLimitXLeft, spawnLimitXRight), transform.position.y);
    }

    void Update()
    {
        if (isScored)
        {
            SpawnFlags();
        }
        else if ((ball.transform.position.x > 8) ||
            ((ball.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.01f) && ball.GetComponent<BallController>().hit))
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnBall();
        AddScore();
    }

    public void AddScore()
    {
        isScored = true;
        score++;
        scoreText.text = score.ToString();        
        a = true;
    }

    void SpawnFlags()
    {
        transform.position = new Vector2(Random.Range(spawnLimitXLeft, spawnLimitXRight), transform.position.y);
        isScored = false;
    }

    void SpawnBall()
    {
        BallController Ball = ball.GetComponent<BallController>();
        Ball.transform.position = Ball.startPos;
        Ball.ball.velocity = Vector2.zero;
        Ball.hit = false;
    }
    
    public void GameOver()
    {
        GameOverScreen.Setup(score);
    }
}
