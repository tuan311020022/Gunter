using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChuyenManChoi : MonoBehaviour
{
    // Start is called before the first frame update
    public string tenMan;
    
    public void LoadMan(){
        SceneManager.LoadScene(tenMan);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player"))
        {
            Debug.Log("hello");
            LoadMan();
        }
    }
}
