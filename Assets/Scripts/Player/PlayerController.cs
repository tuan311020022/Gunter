using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    #region Public Variables
    public int currentHealth;
    public int maxHealth = 100;

    public int currentGrenade;
    public int maxGrenade = 3;

    public Image healthBar;
    #endregion
    Animator animator;
    EffectManager effectManager;
    SoundManager soundManager;
    private void Awake() {
        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void Start() {
        currentHealth = maxHealth;
        currentGrenade = maxGrenade;
    }

    private void Update() {

    }

    public void TakeDamage(int damage)
    {
        // animator     Hit animation
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;
        if(currentHealth <= 0)
        {
           //animator.SetTrigger("Die");
            Destroy(gameObject);
        }
    }

    public void GetHealth(int health)
    {
        currentHealth += health;
        healthBar.fillAmount = currentHealth / 100f;
        if(currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void GetGrenade(int grenade)
    {
        currentGrenade += grenade;
        if(currentGrenade >= maxGrenade)
        {
            currentGrenade = maxGrenade;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.CompareTag("Hit"))
        {
            soundManager.PlaySFX(SoundType.Melee);
            TakeDamage(10);
        }
    }
}
