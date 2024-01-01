using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestEnemy : EnemyController
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

    private int direction = -1;
    private float directionTimer = 2;
    private float nextDirection = 0;
    private bool inRange;

    // Ground Check
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToPlayer = player.position.x - transform.position.x;

        Attack();
        if(detectPlayer)
        {
            FlipIfNeeded(distanceToPlayer);
            MoveEnemy();
        }
        else if(!detectPlayer)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            EnemyPatrol();
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
        }else{
            detectPlayer = false;
        }
    }

    void MoveEnemy()
    {
        anim.SetBool("Walk", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void EnemyPatrol()
    {
        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }

        anim.SetBool("Walk", true);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Flip();
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);

        // Gizmos.color = Color.red;
        // Gizmos.DrawWireSphere(groundCheck.transform.position, groundCheckRadius);
    }

}
