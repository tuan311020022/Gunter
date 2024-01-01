using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostage : MonoBehaviour
{
    [SerializeField] float destroyTime;
    private float speed = 4;

    bool isRelease;
    Animator animator;

    BoxCollider2D boxCollider;


    
    private void Start() {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if(isRelease)
        {
            Run();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Release");
            boxCollider.enabled = false;
            isRelease = true;
        }
        else{
            isRelease = false;
        }
    }

    private void Run()
    {
        animator.SetTrigger("Run");
        transform.Translate(Vector2.left * speed * Time.deltaTime); 
        Destroy(gameObject, destroyTime);
    }
}
