using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private int damage;
    private float speed = 3;

    private float destroyTime = 5;

    public Move move;

    public SpriteRenderer bulletRender;

    // Start is called before the first frame update
    void Start()
    {
        move = FindObjectOfType<Move>();
        bulletRender = GetComponent<SpriteRenderer>();

        if (move.mySpriteRenderer.flipX == false)
        {
            // Flip vien dan
            bulletRender.flipX = false;
        }
        else if (move.mySpriteRenderer.flipX == true)
        {
            // Flip vien dan
            bulletRender.flipX = true;
        }
    }

    // Update is called once per frame

    void Update()
    {
        Destroy(gameObject, destroyTime);
        if (bulletRender.flipX == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("RangeEnemy"))
        {
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}
