using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : EnemyController
{
    public Transform enemySpawner;
    public GameObject enemyPrefabs;


    public float playerCheckRadius;
    public LayerMask playerLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnerEnemy()
    {
        if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
        {
 
        }
    }
}
