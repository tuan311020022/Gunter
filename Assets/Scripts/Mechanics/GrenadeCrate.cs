using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCrate : MonoBehaviour
{   
    public int grenadeNumber = 1;
    EffectManager effectManager;
    SoundManager soundManager;

    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.GetGrenade(grenadeNumber);
            soundManager.PlaySFX(SoundType.Heal);
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Player"))
    //     {   
    //         PlayerController player = other.gameObject.GetComponent<PlayerController>();
    //         player.GetGrenade(grenadeNumber);
    //         Destroy(gameObject);
    //     }
    // }
}
