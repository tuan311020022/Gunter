using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public int speed;

    public float throwGrenadeRate = 2;
    private float nextThrow = 0;

    public GameObject grenadePrefab;
    public Transform grenadePosition;

    public GameObject target;

    private Animator animator;

    private Rigidbody2D rb2D;

    public Transform playerCheck;
    public float playerCheckRadius = 0.1f;
    public LayerMask playerLayer;

    private AudioSource audioSource;
    public AudioClip hitSound;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CanThrow();
        Flip();
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        if(target.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(speed * Time.deltaTime,0,0);
        }else{
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(speed * Time.deltaTime,0,0);
        }
        transform.localScale = scale;
    }
    
    void CanThrow()
    {
        if(Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayer))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
      if(Time.time > nextThrow)
      {
        animator.SetTrigger("Attack");
        nextThrow = Time.time + throwGrenadeRate;
        GameObject grenade = Instantiate(grenadePrefab, grenadePosition.transform.position, transform.rotation);
        //grenade.transform.eulerAngles = new Vector3(0, 0, 90f);
        
      }
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }
}
