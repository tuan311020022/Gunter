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

    private bool inRange;

    #endregion
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distanceToPlayer = player.position.x - transform.position.x;
        FlipIfNeeded(distanceToPlayer);

        Attack();


        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        if(detectPlayer)
        {
            MoveEnemy();
        }else if(!detectPlayer)
        {
            anim.SetBool("Walk", false);
        }
        // else{
        //     MoveEnemy(currentPosition);
        // }
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

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }

}
