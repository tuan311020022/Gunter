using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public int currentGrenade;
    public int grenadeNumber = 3;

    Animator animator;
    private void Start() {
        currentHealth = maxHealth;
        currentGrenade = grenadeNumber;
    }

    private void Update() {
        //ReleaseHostage();
    }

    public void TakeDamage(int damage)
    {
        // animator     Hit animation
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
           //animator.SetTrigger("Die");
            Destroy(gameObject);
        }
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void GetGrenade(int grenade)
    {
        currentGrenade += grenade;
        
    }


    Rigidbody2D rigidbody2d;

    Vector2 lookDirection = new Vector2(1,0);
    
    float rayDistance = 50f;
    public GameObject RayCheck;

    void ReleaseHostage()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            // RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rayDistance, LayerMask.GetMask("NPC"));        
            // if (hit.collider != null)
            // {
            //     Debug.DrawRay(transform.position, hit.point, Color.green);
            //     Debug.Log("HIt");
            //     Hostage hostage = hit.collider.GetComponent<Hostage>();
            //     if (hostage != null)
            //     {   
            //         hostage.Release();
            //     }
            // }
        }
    
    }

    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.gameObject.CompareTag("Enemy"))
    //     {
    //         EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
    //         enemy.TakeDamage(10);
    //     }
    // }
}
