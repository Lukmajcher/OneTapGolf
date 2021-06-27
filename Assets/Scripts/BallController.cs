using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D ball;
    private float increaseSpeed = 0.5f;
    private float powerUpTime;

    public GameObject partner;
    public bool hit;
    public Vector2 startPos;

    void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !hit)  
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.Space) && !hit)
        {
            PowerUp();
        }
        SpawnManager increase = partner.GetComponent<SpawnManager>();
        if ((increase.isScored == false) && increase.a)
        {
            increaseSpeed += 0.1f;
            increase.a = false;
        }
    }

    private void Shoot()
    {
        ball.AddForce(Vector2.one * increaseSpeed * 10 * powerUpTime, ForceMode2D.Impulse);
        powerUpTime = 0;
        hit = true;
    }

    private void PowerUp()
    {
        powerUpTime += Time.deltaTime;
    }
} 
