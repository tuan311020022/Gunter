using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyController
{ 
    #region Public
    public float fireRate;
    // public float detectionRadius = 10f;
    // public float attackRange = 2f;
    public Transform firePoint;
    public GameObject bulletPrefabs;
    public float playerCheckRadius;
    public LayerMask playerLayer;
    #endregion

    #region Private
    private float distanceToPlayer;

    private float nextFire;

    private bool isFacingRight = true;
    #endregion
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToPlayer = player.position.x - transform.position.x;
        FlipIfNeeded(distanceToPlayer);

        Attack();
    }

    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            if(Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                GameObject enemyBullet = Instantiate(bulletPrefabs, firePoint.position, Quaternion.identity);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }

}
