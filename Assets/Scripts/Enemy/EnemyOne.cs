using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    // Huong di va thoi gian chuyen huong
    int direction = 1;
    float timer, changeTime = 2f;

    // Toc do
    public float speed = 5f;

    Animator animator;

    Rigidbody2D enemyRB;
    private AudioSource audioSource;
    public AudioClip hitSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirection();
    }
    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime , 0f, 0f);
    }

    void ChangeDirection()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

}
