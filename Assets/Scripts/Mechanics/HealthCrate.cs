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
            player.GetHealth(health);
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     PlayerController player = other.gameObject.GetComponent<PlayerController>();
    //     if (other.gameObject.CompareTag("Player")) 
    //     {
    //         player.GetHealth(health);
    //         Destroy(gameObject);
    //     }
    // }
}
