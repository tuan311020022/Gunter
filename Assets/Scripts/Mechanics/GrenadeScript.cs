using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public float throwForce;

    public float Delay = 2f;
    public float grenadeRadius;
    public float damage;

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
        rb2D.AddForce(Vector3.right * throwForce, ForceMode2D.Impulse);
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
        Destroy(gameObject);
    }


}
