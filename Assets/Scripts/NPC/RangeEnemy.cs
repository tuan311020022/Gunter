using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeEnemy : EnemyController
{ 
     #region Public
    public float fireRate;
    public Transform firePoint;
    public GameObject bulletPrefabs;
    public float playerCheckRadius;
    public LayerMask playerLayer;
    #endregion

    #region Private
    private float distanceToPlayer;
    private float nextFire;
    private bool detectPlayer;

    #endregion
    private void Awake() {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        sprite = GetComponent<SpriteRenderer>();

        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>(); 
    }

    void Update()
    {
        distanceToPlayer = player.position.x - transform.position.x;
        
        if (!isDead)
        {
            Attack();
            if(detectPlayer)
            {
                FlipWhenSpottedPlayer(distanceToPlayer);
                MoveEnemy();
            }
        }
    }

    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            detectPlayer = true;
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject enemyBullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            }
        }else if(!Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer)){
            detectPlayer = false;
            anim.SetBool("Walk", false);
        }
    }

    void MoveEnemy()
    {
        anim.SetBool("Walk", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
