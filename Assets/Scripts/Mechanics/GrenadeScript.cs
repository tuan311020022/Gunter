using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    private float speed = 6;

    private float destroyTime = 3;

    public Move move;

    public SpriteRenderer grenadeRender;

    private float throwForce = 5f;

    public float Delay;

    public Transform playerCheck;
    public float grenadeRadius;
    public LayerMask playerLayer;

    public int damage;

    private float countDown;
    private bool isExplode;


    private Animator anim;

    private Rigidbody2D rb2D;

    public GameObject ExplosionEffect;

    EffectManager effectManager;
    SoundManager soundManager;

    private void Awake()
    {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start()
    {
        move = FindObjectOfType<Move>();
        grenadeRender = GetComponent<SpriteRenderer>();

        if (move.mySpriteRenderer.flipX == false)
        {
            // Flip vien dan
            grenadeRender.flipX = false;
        }
        else if (move.mySpriteRenderer.flipX == true)
        {
            // Flip vien dan
            grenadeRender.flipX = true;
        }
        //countDown = Delay;
        //anim = GetComponent<Animator>();  
        //rb2D = GetComponent<Rigidbody2D>();
        //rb2D.AddForce(Vector3.right * throwForce, ForceMode2D.Force);


    }

    void Update()
    {
        Destroy(gameObject, destroyTime);
        if (grenadeRender.flipX == false)
        {
            transform.Translate(Vector2.up * (speed + 3) * Time.deltaTime);
            transform.Translate(Vector2.right * (speed - 3) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.up * (speed + 3) * Time.deltaTime);
            transform.Translate(Vector2.left * (speed - 3) * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            soundManager.PlaySFX(SoundType.Explosion);
            effectManager.PlayEffect(EffectType.Grenade, transform);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("RangeEnemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            soundManager.PlaySFX(SoundType.Explosion);
            effectManager.PlayEffect(EffectType.Grenade, transform);
            Destroy(gameObject);
        }
    }
}
