using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossProjectile : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;

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

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(damage);
            effectManager.PlayEffect(EffectType.BossLaser, transform);
            soundManager.PlaySFX(SoundType.BodyHit);
            Destroy(gameObject);
        }     
    }

}
