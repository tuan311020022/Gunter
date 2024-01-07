using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    [SerializeField] float destroyTime;
    [SerializeField] ParticleSystem myParticle;
    private float speed = 4;

    bool isRelease;
    Animator animator;

    BoxCollider2D boxCollider;

    ScoreManager scoreManager;
    private void Start() {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

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
            PlayParticle();
            scoreManager.AddScore(100);
        }
        else{
            isRelease = false;
        }
    }

    private void PlayParticle()
    {
        Instantiate(myParticle, transform.position, Quaternion.identity);
    }

}
