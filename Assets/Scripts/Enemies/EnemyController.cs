using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth;

    public float currentHealth;

    SpriteRenderer sprite;

    Animator anim;

    Rigidbody2D rb2D;

    void Start() {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {

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
