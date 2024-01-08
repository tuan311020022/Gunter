using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject[] gameObjects;

    private void OnTriggerEnter2D(Collider2D other) {
        int randomIndex = Random.Range(0, gameObjects.Length);
        
        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(gameObjects[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
