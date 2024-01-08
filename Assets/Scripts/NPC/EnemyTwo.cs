using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyTwo : EnemyController
{   

    public float throwGrenadeRate = 2;
    private float nextThrow = 0;

    public GameObject grenadePrefab;
    public Transform grenadePosition;

    public Transform playerCheck;
    public float playerCheckRadius = 0.1f;
    public LayerMask playerLayer;

    private AudioSource audioSource;
    public AudioClip hitSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CanThrow();
    }
    
    void CanThrow()
    {
        if(Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayer))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
      if(Time.time > nextThrow)
      {
        anim.SetTrigger("Attack");
        nextThrow = Time.time + throwGrenadeRate;
        GameObject grenade = Instantiate(grenadePrefab, grenadePosition.transform.position, transform.rotation);
        //grenade.transform.eulerAngles = new Vector3(0, 0, 90f);
        
      }
    }

    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }
}
