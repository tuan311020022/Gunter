using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyController : MonoBehaviour
{
    #region Public
    public float maxHealth;
    public float moveSpeed;
    public int score;
    public Transform player;

    #endregion

    #region Protected
    protected bool facingRight;

    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isDead = false;
    protected ScoreManager scoreManager;

    #endregion
    void Start() {
        player = GameObject.FindWithTag("Player").transform;

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();    

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
        }else {
            StartCoroutine(DamageColorCoroutine());
        }
    }

    void Dead()
    {
        isDead = true;
        anim.SetBool("Dead", true);
        Destroy(gameObject, 0.9f);
        if(isDead && maxHealth == 0)
        {
            scoreManager.AddScore(score);
        }
    }
    IEnumerator DamageColorCoroutine()
    {
        sprite.color = Color.yellow;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }



}
