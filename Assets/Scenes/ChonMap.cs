using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChonMap : MonoBehaviour
{
    // Start is called before the first frame update
    public string tenMan;
    public void LoadMan1(){
        SceneManager.LoadScene(1);
    }
    public void LoadMan2(){
        SceneManager.LoadScene(3);
    }

    // Update is called once per frame
}
