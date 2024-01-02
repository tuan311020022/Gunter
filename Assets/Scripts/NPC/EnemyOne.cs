using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    #region Public
    public int damage;
    public float speed;
    public float timer; // Attack cooldown

    // Ground Check
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // Player Check
    public float playerCheckRadius;
    public LayerMask playerLayer;
    #endregion


    #region Private
    private bool facingRight;

    private bool detectPlayer;
    private bool cooldown;
    private float intTimer;

    private Transform player;
    #endregion
    // Ground check

    // Player Check



    Animator anim;

    Rigidbody2D enemyRB;

    SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;
    void Start()
    {
        intTimer = timer;

        anim = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
  
    void Update()
    {
        if(!detectPlayer)
        {
            EnemyPatrol();
            StopAttack();
        }else if(detectPlayer && cooldown == false)
        {
            Attack();
            ChasePlayer();
        }

        if(cooldown)
        {
            anim.SetBool("Attack", false);
        }
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        speed *= -1;
        anim.SetBool("Walk", true);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Flip();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            Flip();
        }       
    }

    void EnemyPatrol()
    {
        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    void ChasePlayer()
    {
        anim.SetBool("Walk", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            anim.SetTrigger("Attack");
        }
        cooldown = true;
    }

    void StopAttack()
    {
        cooldown = false;
        anim.SetBool("Attack", false);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
