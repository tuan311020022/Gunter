using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    Animator animator;
    private void Start() {
        currentHealth = maxHealth;
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
}
