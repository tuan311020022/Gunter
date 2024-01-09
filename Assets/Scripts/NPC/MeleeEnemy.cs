using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    #region Public Var
    public float attackDistance; //Minimum distance for attack
    public float timer; //Timer for cooldown between attacks

    // Ground Check
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    // Player Check
    public float playerCheckRadius = 10f;
    public LayerMask playerLayer;
    #endregion


    #region Private Var
    private float distanceToPlayer;

    private float distance;

    private bool isPatrol;

    #endregion


    private void Start() {
        player = GameObject.FindWithTag("Player").transform;

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();   
    }
    void Update()
    {
        //distanceToPlayer = player.position.x - transform.position.x;
        //FlipWhenSpottedPlayer(distanceToPlayer);

        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            isPatrol = false;
            EnemyLogic();
            FlipWhenSpottedPlayer(distanceToPlayer);
        }
        // EnemyPatrol();
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if(!isDead)
        {
            if(!isPatrol)
            {
                EnemyChase();
                Attack();
            }else{
                anim.SetBool("Walk", false);
            }
        }


    }
    void Attack()
    {
        distanceToPlayer = player.position.x - transform.position.x;
        if(distance < attackDistance && !isPatrol)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Attack", true);
        }
    }
    void EnemyChase()
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Attack", false);
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
    // void EnemyPatrol()
    // {
    //     isPatrol = true;
    //     //transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    //     anim.SetBool("Walk", true);
    //     if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) && isPatrol)
    //     {
    //         Flip();
    //     }

    // }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Obstacle"))
    //     {
    //         isPatrol = true;
    //         Flip();
    //     }
    // }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
