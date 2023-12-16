using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth;

    protected float currentHealth;

    SpriteRenderer spriteRenderer;
    Animator anim;

    private void Start() {
        currentHealth = maxHealth;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            anim.SetTrigger("Dead");
        }
        else{
            StartCoroutine(DamageColorCoroutine());
        }
    }

    void GainHealth(int health)
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += health;
        }
        else{
            currentHealth = maxHealth;
        }
    }

    IEnumerator DamageColorCoroutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
