using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossProjectile : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;
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
            Destroy(gameObject);
        }     
    }

}
