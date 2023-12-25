using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public int health;
    public float fireRate;
     private float nextFire = 0;
    private bool isDead = false;
    private Animator anim;

    public GameObject bossProjectilePrefab;

    public Transform bossWeapon;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        Attack();

        nextFire -= Time.deltaTime;
    }

    void Attack()
    {
        if(!isDead)
        {
            if(nextFire < 0) 
            {
                nextFire = fireRate;
                anim.SetTrigger("Shoot");
                GameObject fireBall = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject fireBall2 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject fireBall3 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject fireBall4 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                fireBall.transform.eulerAngles = new Vector3(0, 0, 180f);
                fireBall2.transform.eulerAngles = new Vector3(0, 0, 160f);
                fireBall3.transform.eulerAngles = new Vector3(0, 0, 140f);
                fireBall4.transform.eulerAngles = new Vector3(0, 0, 120f);
            }
        }
    }
    void Dead()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
    }
}
