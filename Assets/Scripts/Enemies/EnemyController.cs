using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Stats
    public float speed;
    public int damage;

    public int maxHealth;

    protected float currentHealth;

    protected bool facingRight;
    private bool isDead;
        
    // Ground check
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    protected Transform target;

    protected GameObject targetGO;

    protected SpriteRenderer sprite;

    Animator anim;

    Rigidbody2D rb2D;

    void Start() {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        
        target = FindObjectOfType<PlayerController>().transform;
        targetGO = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }

        transform.Translate(speed * Time.deltaTime * transform.right);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            anim.SetTrigger("Die");
            speed = 0;        
            Destroy(gameObject, 0.9f);
        }
        else{
            StartCoroutine(DamageColorCoroutine());
        }
    }

    IEnumerator DamageColorCoroutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        speed *= -1;
        anim.SetFloat("Speed", 1);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Flip();
        }
    }
}
