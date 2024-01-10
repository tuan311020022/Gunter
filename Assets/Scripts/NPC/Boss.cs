using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Boss : EnemyController
{
    #region Public Var
    // Spawn Bullet
    public float fireRate = 3;
    public float fireRate1 = 20;
    private float nextFire = 0;
    private float nextFire1 = 0;

    public GameObject bossProjectilePrefab;
    public GameObject bossProjectilePrefab2;

    public Transform bossWeapon;

    // Spawn Enemy
    public float spawnRate;
    private float nextSpawn = 0;
    public Transform enemySpawner;
    public GameObject[] enemyPrefabs;

    // Check player
    public float playerCheckRadius;
    public LayerMask playerLayer;
    #endregion

    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    void Start() {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update() {
        if(!isDead)
        {
            Attack();
        }
    }

    void Attack()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
            if(Time.time > nextFire ) 
            {
                nextFire = Time.time + fireRate;
                anim.SetTrigger("HighAttack");
                soundManager.PlaySFX(SoundType.BossLaser);
                GameObject bossBullet = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet1 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);
                GameObject bossBullet2 = Instantiate(bossProjectilePrefab, bossWeapon.position, bossWeapon.rotation);

                bossBullet.transform.eulerAngles = new Vector3(0, 0, 140f);
                bossBullet2.transform.localScale = new Vector3(3,3);

                bossBullet1.transform.eulerAngles = new Vector3(0, 0, 150f);
                bossBullet1.transform.localScale = new Vector3(3,3);

                bossBullet2.transform.eulerAngles = new Vector3(0, 0, 160f);
                bossBullet2.transform.localScale = new Vector3(3,3);

            }
            if(Time.time > nextFire1)
            {
                nextFire1 = Time.time + fireRate1;
                anim.SetTrigger("LowAttack");
                soundManager.PlaySFX(SoundType.BossLaser);
                GameObject bossRetroBullet = Instantiate(bossProjectilePrefab2, bossWeapon.position, bossWeapon.rotation);

                bossRetroBullet.transform.eulerAngles = new Vector3(0, 0, 180f);
            }

            if(Time.time > nextSpawn)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                int randomIndex1 = Random.Range(0, enemyPrefabs.Length);
                nextSpawn = Time.time + spawnRate;
                soundManager.PlaySFX(SoundType.EnemySpawn);
                GameObject spawnEnemy1 = Instantiate(enemyPrefabs[randomIndex], enemySpawner.position, enemySpawner.rotation);
                GameObject spawnEnemy2 = Instantiate(enemyPrefabs[randomIndex1], enemySpawner.position, enemySpawner.rotation);

            }
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
