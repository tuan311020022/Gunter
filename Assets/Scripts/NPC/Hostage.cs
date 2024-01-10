using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] ParticleSystem myParticle;
    public int score;
    public int hpRestore;
    private float speed = 4;

    bool isRelease;
    Animator animator;

    BoxCollider2D boxCollider;

    ScoreManager scoreManager;
    EffectManager effectManager;

    SoundManager soundManager;
    private void Start() {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        effectManager = FindObjectOfType<EffectManager>();
        soundManager = FindObjectOfType<SoundManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update() {
        if(isRelease)
        {
            Run();
        }
    }

    private void Run()
    {
        animator.SetTrigger("Run");
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
        Destroy(gameObject, destroyTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Release");
            boxCollider.enabled = false;
            isRelease = true;
            effectManager.PlayEffect(EffectType.Rescue, transform);
            soundManager.PlaySFX(SoundType.Rescue);
            scoreManager.AddScore(score);
            player.GetHealth(hpRestore);
        }
        else{
            isRelease = false;
        }
    }

}
