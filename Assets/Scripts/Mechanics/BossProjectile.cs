using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossProjectile : MonoBehaviour
{
    public float speed = 10f;

    public float destroyTime;

    public int damage;

    private GameObject enemy;

    private Vector2 direction;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("RangeEnemy");
        
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.transform.localScale.x > 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);    
        }else{
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.TakeDamage(10);
            Destroy(gameObject);
        }     
    }
    
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
}
