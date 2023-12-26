using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] gameObjects;

    // int randomObjects = Random.RandomRange()
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Projectiles"))
        {
            anim.SetTrigger("Break");
            Instantiate(gameObjects[0], Vector2.zero, Quaternion.identity);
        }
    }
}
