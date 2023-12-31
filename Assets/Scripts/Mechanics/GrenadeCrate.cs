using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCrate : MonoBehaviour
{   
    public int grenadeNumber = 1;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.GetGrenade(grenadeNumber);
            Destroy(gameObject);
        }
    }
}
