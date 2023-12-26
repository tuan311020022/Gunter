using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenade : MonoBehaviour
{
    public float throwForce;

    public float Delay;

    public Transform playerCheck;
    public float grenadeRadius;
    public LayerMask playerLayer;

    public int damage;

    private float countDown;
    private bool isExplode;


    private Animator anim;

    private Rigidbody2D rb2D;

    public GameObject ExplosionEffect;
    void Start()
    {
        countDown = Delay;
        anim = GetComponent<Animator>();  
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector3.right * throwForce, ForceMode2D.Force);


    }

    void Update()
    {
        countDown -= Time.deltaTime;

        if(countDown <= 0 && !isExplode)
        {
            Explode();
            isExplode = true;
        }
    }

    private void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);

        // Collider2D[] Around = Physics2D.OverlapCircleAll(playerCheck.position, grenadeRadius, playerLayer);
        
        // foreach(Collider2D inside in Around)
        // {
        //     if(inside.transform.tag == "Player")
        //     {
        //         PlayerController ps = GetComponent<PlayerController>();
        //         ps.TakeDamage(10);
        //     }
        // }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(playerCheck.position, grenadeRadius);
    }
}
