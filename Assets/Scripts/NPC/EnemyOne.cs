using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    public int damage;
    public float speed;
    bool facingRight;
    bool isDead;

    // Ground check
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // Player Check
    public Transform playerCheck;
    public float playerCheckRadius;
    public LayerMask playerLayer;


    Animator animator;

    Rigidbody2D enemyRB;

    SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        // timer = changeTime;
    }

    // Update is called once per frame
  
    void Update()
    {
        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
        Attack();
    }

    public void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        speed *= -1;
        animator.SetFloat("Speed", 1);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Flip();
        }
    }


    void Attack()
    {
        if(Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayer))
        {
            animator.SetTrigger("Attack");
            
            PlayerController player = gameObject.GetComponent<PlayerController>();
            if(player != null)
            {
                player.TakeDamage(damage);
            }
        }
        else{
            return;
        }
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }
}
