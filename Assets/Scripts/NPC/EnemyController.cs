using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Public
    public float maxHealth;
    public float moveSpeed;
    public Transform player;

    #endregion

    #region Protected

    protected bool facingRight;

    protected SpriteRenderer sprite;

    protected Animator anim;

    protected Rigidbody2D rb2D;
    #endregion

    void Start() {
        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        //targetDistance = transform.position.x - player.position.x;
    }

    protected void Flip()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        moveSpeed *= -1;
        anim.SetBool("Walk", true);
    }

    protected void FlipWhenSpottedPlayer(float horizontalDistance) // horizontalDistance = player.position.x - transform.position.x
    {
        if ((horizontalDistance > 0 && !facingRight) || (horizontalDistance < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
        if(maxHealth <= 0)
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
