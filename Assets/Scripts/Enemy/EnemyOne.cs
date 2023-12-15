using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    // Huong di va thoi gian chuyen huong
    int direction = 1;
    float timer, changeTime = 2f;

    // Toc do
    public float speed = 3f;

    // Animation khi chuyen huong
    bool isFacingLeft;
    Animator animator;

    Rigidbody2D enemyRB;

    SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
    }

    void ChangeDirection()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 pos = transform.position;
        if (isFacingLeft)
        {
            animator.SetFloat("Move X", 0);
            pos.x += speed * Time.deltaTime * direction;
        }
        else
        {
            animator.SetFloat("Move X", 0);
            pos.x += speed * Time.deltaTime * direction;
            spriteRenderer.flipX = direction > 0;
        }
        enemyRB.MovePosition(pos);

    }

}
