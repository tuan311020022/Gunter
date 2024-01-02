using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroBullet : MonoBehaviour
{
    public float speed;

    public float destroyTime;

    public int damage;

    public float growthRate;

    void Start()
    {        
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
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
            Destroy(gameObject);
        }     
    }

}
