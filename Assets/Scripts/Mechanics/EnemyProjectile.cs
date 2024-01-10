using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;

    private GameObject enemy;

    private Vector2 direction;
    EffectManager effectManager;
    SoundManager soundManager;
    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("RangeEnemy");

        Destroy(gameObject, destroyTime);

        SetInitialDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void SetInitialDirection()
    {
        // Get the initial direction when the projectile is created
        direction = Vector2.left;
 
        // Flip the direction if the enemy is facing left
        if (enemy.transform.localScale.x < 0)
        {
            direction = -direction;
        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            soundManager.PlaySFX(SoundType.BodyHit);
            effectManager.PlayEffect(EffectType.HitYellow,transform);
            player.TakeDamage(damage);
            Destroy(gameObject);
        }     
    }
}
