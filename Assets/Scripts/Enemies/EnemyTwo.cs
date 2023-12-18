using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : EnemyController
{
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
    }

    // Update is called once per frame
    void Update()
    {

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
}
