using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Stats
    public float speed;
    public int damage;

    public int health;

    // Distance
    public float attackDistance;

    public float viewDistance;

    protected bool facingRight = false;

    protected Transform target;
    protected float targetDistance;

    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;

    // Ground check
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    Animator anim;
    // Update is called once per frame

    void Start() {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.right);

        if(!Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer))
        {
            Flip();
        }
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
}
