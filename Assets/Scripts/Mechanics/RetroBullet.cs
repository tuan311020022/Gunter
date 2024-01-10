using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroBullet : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;

    public float growthRate;
    EffectManager effectManager;
    SoundManager soundManager;
    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {        
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.localScale += new Vector3(growthRate, growthRate, 0f) * speed * Time.deltaTime;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damage);
            soundManager.PlaySFX(SoundType.Explosion);
            effectManager.PlayEffect(EffectType.HitRed, transform);
            Destroy(gameObject);
        }     
    }

}
