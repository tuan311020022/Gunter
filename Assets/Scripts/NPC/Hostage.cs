using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] ParticleSystem myParticle;
    public int score;
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
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
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
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Release");
            boxCollider.enabled = false;
            isRelease = true;
            effectManager.PlayEffect(EffectType.Rescue, transform);
            soundManager.PlaySFX(SoundType.Rescue);
            scoreManager.AddScore(score);
        }
        else{
            isRelease = false;
        }
    }

}
