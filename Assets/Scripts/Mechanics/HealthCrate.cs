using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCrate : MonoBehaviour
{
    public int health;

    private void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player")) 
        {
            if(player.currentHealth < player.maxHealth)
            {
                player.GetHealth(health);
                Destroy(gameObject);
            }
            else{
                player.currentHealth = player.maxHealth;
                Destroy(gameObject);
            }
        }


    }
}
