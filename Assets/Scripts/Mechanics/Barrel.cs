using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void OnCollisionEnter2D(Collision2D other) {
        int randomIndex = Random.Range(0, gameObjects.Length);
        
        if(other.gameObject.CompareTag("Bullet"))
        {
            Instantiate(gameObjects[randomIndex], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
