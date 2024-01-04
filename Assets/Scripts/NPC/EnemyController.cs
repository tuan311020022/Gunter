using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Public
    public int maxHealth;

    public float moveSpeed;
    public Transform player;

    #endregion

    #region Private
    private float currentHealth;

    #endregion

    #region Protected
    protected bool facingRight;

    protected bool detectPlayer;

    protected float targetDistance;

    protected SpriteRenderer sprite;

    protected Animator anim;

    protected Rigidbody2D rb2D;
    #endregion

    void Start() {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        targetDistance = transform.position.x - player.position.x;
    }

    protected void Flip()
    {
        // Vector3 scale = transform.localScale;

        // if(player.transform.position.x > transform.position.x )
        // {
        //     scale.x = Mathf.Abs(scale.x) * -1;
        // }else if (player.transform.position.x < transform.position.x){
        //     scale.x = Mathf.Abs(scale.x);
        // }
        
        // transform.localScale = scale;
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        moveSpeed *= -1;
        anim.SetBool("Walk", true);
    }

    protected void FlipIfNeeded(float horizontalDistance) // horizontalDistance = player.position.x - transform.position.x
    {
        if ((horizontalDistance > 0 && !facingRight) || (horizontalDistance < 0 && facingRight))
        {
            // Flip the enemy
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Dead();
        }
        else{
            StartCoroutine(DamageColorCoroutine());
        }
    }

    void Dead()
    {
        anim.SetTrigger("Die");
        
        Destroy(gameObject, 0.9f);
    }

    IEnumerator DamageColorCoroutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }



}
