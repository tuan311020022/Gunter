using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public int currentGrenade;
    public int grenadeNumber = 3;

    Animator animator;
    private void Start() {
        currentHealth = maxHealth;
        currentGrenade = grenadeNumber;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        // animator     Hit animation
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
           //animator.SetTrigger("Die");
            Destroy(gameObject);
        }
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void GetGrenade(int grenade)
    {
        currentGrenade += grenade;
        
    }
}
