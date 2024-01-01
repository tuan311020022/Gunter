using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossProjectile : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;

    private GameObject enemy;

    private Vector2 direction;
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
            player.TakeDamage(damage);
            Destroy(gameObject);
        }     
    }

}
