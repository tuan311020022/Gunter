using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : EnemyController
{
    // Huong di va thoi gian chuyen huong
    int direction = 1;
    float timer, changeTime = 2f;

    bool isFacingLeft;

    private bool isDead = false;

    Animator anim;

    Rigidbody2D enemyRB;

    SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;
    void Start()
    {
        anim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
    }

    void Move()
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
            anim.SetFloat("Speed", 1);
            pos.x += speed * Time.deltaTime * direction;
        }
        else
        {
            anim.SetFloat("Speed", 1);
            pos.x += speed * Time.deltaTime * direction;
            spriteRenderer.flipX = direction > 0;
        }
        enemyRB.MovePosition(pos);
    }

    void Dead(int health)
    {
        if(health <= 0)
        {
            isDead = true;
            anim.SetTrigger("Dead");
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
    void Attack()
    {
        // if(!isDead)
        // {
        //     anim.SetTrigger("Attack");
        // }
    }
}
