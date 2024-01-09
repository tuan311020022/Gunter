using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] gameObjects;

    EffectManager effectManager;
    SoundManager soundManager;
    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        int randomIndex = Random.Range(0, gameObjects.Length);
        
        if(other.gameObject.CompareTag("Bullet"))
        {
            soundManager.PlaySFX(SoundType.Break);
            effectManager.PlayEffect(EffectType.Break, transform);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(gameObjects[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
