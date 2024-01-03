using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    private float speed = 6;

    private float destroyTime = 3;

    public Move move;

    public SpriteRenderer grenadeRender;

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
        move = FindObjectOfType<Move>();
        grenadeRender = GetComponent<SpriteRenderer>();

        if (move.mySpriteRenderer.flipX == false)
        {
            // Flip vien dan
            grenadeRender.flipX = false;
        }
        else if (move.mySpriteRenderer.flipX == true)
        {
            // Flip vien dan
            grenadeRender.flipX = true;
        }
        //countDown = Delay;
        //anim = GetComponent<Animator>();  
        //rb2D = GetComponent<Rigidbody2D>();
        //rb2D.AddForce(Vector3.right * throwForce, ForceMode2D.Force);


    }

    void Update()
    {
        Destroy(gameObject, destroyTime);
        if (grenadeRender.flipX == false)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        //countDown -= Time.deltaTime;

        //if(countDown <= 0 && !isExplode)
        //{
        //    Explode();
        //    isExplode = true;
        //}
    }

    //private void Explode()
    //{
    //    Instantiate(ExplosionEffect, transform.position, transform.rotation);

    //    // Collider2D[] Around = Physics2D.OverlapCircleAll(playerCheck.position, grenadeRadius, playerLayer);
        
    //    // foreach(Collider2D inside in Around)
    //    // {
    //    //     if(inside.transform.tag == "Player")
    //    //     {
    //    //         PlayerController ps = GetComponent<PlayerController>();
    //    //         ps.TakeDamage(10);
    //    //     }
    //    // }

    //    Destroy(gameObject);
    //}

    //private void OnDrawGizmosSelected() {
    //  Gizmos.color = Color.red;
    //  Gizmos.DrawWireSphere(playerCheck.position, grenadeRadius);
    //}
}
