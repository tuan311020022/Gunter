using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
    #region Public Var
    public float fireRate = 3;
    public float fireRate1 = 20;
    private float nextFire = 0;
    private float nextFire1 = 0;


    public GameObject bossProjectilePrefab;
    public GameObject bossProjectilePrefab2;

    public Transform bossWeapon;
    public Transform yBound;

    public float playerCheckRadius;
    public LayerMask playerLayer;
    #endregion
    //private bool isDead = false;

    void Start() {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();    

    }

    void Update() {
        if(!isDead)
        {
            Attack();
        }
    }

    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            if(Time.time > nextFire ) 
            {
                nextFire = Time.time + fireRate;
                anim.SetTrigger("HighAttack");
                GameObject bossBullet = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet1 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet2 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);

                bossBullet.transform.eulerAngles = new Vector3(0, 0, 90f);

                bossBullet1.transform.eulerAngles = new Vector3(0, 0, 120f);
                bossBullet1.transform.localScale = new Vector3(2,2);

                bossBullet2.transform.eulerAngles = new Vector3(0, 0, 140f);
                bossBullet2.transform.localScale = new Vector3(3,3);
                


            }
            if(Time.time > nextFire1)
            {
                nextFire1 = Time.time + fireRate1;
                anim.SetTrigger("LowAttack");
                GameObject bossRetroBullet = Instantiate(bossProjectilePrefab2, bossWeapon.position, bossWeapon.rotation);

                bossRetroBullet.transform.eulerAngles = new Vector3(0, 0, 180f);
            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
