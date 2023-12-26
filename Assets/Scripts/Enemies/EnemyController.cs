using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage;

    public int maxHealth;

    private float currentHealth;

    SpriteRenderer sprite;

    Animator anim;

    Rigidbody2D rb2D;

    void Start() {
        currentHealth = maxHealth;

        anim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        // target = FindObjectOfType<PlayerController>().transform;
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {


        //transform.Translate(speed * Time.deltaTime * transform.right);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            anim.SetTrigger("Die");
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



}
