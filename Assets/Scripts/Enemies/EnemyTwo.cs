using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public GameObject grenadePrefab;

    Animator animator;

    Rigidbody2D enemyRB;

    SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void throwGrenade()
    {
      //  Instantiate(grenadePrefab, .transform.position, Quaternion.identity);
    }
}
