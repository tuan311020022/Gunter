using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public float fireRate = 3;
    public float fireRate1 = 20;
    private float nextFire = 0;
    private float nextFire1 = 0;

    private Animator anim;

    public GameObject bossProjectilePrefab;
    public GameObject bossProjectilePrefab2;

    public Transform bossWeapon;

    public float playerCheckRadius;
    public LayerMask playerLayer;

    private Transform player;

    Rigidbody2D rb2D;

    void Start() {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Attack();
    }

    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            if(Time.time > nextFire ) 
            {
                nextFire = Time.time + fireRate;
                anim.SetTrigger("Shoot");
                GameObject bossBullet = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet1 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet2 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);

                bossBullet.transform.eulerAngles = new Vector3(0, 0, 90f);

                bossBullet1.transform.eulerAngles = new Vector3(0, 0, 150f);
                bossBullet1.transform.localScale = new Vector3(5,5);

                bossBullet2.transform.eulerAngles = new Vector3(0, 0, 120f);
                bossBullet2.transform.localScale = new Vector3(2,2);
                



            }
            if(Time.time > nextFire1)
            {
                nextFire1 = Time.time + fireRate1;
                anim.SetTrigger("Shoot");
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
