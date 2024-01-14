using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChonMap : MonoBehaviour
{
    // Start is called before the first frame update
    public string tenMan;
    public void LoadMan1(){
        SceneManager.LoadScene(4);
    }
    public void LoadMan2(){
        SceneManager.LoadScene(5);
    }
    public void LoadManExtra(){
        SceneManager.LoadScene(8);
    }

    // Update is called once per frame
}
