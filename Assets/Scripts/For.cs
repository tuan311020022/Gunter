using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Learn for");
        int maxMinion = 7;
        for (int i=0; i < maxMinion; i++)
        {
            this.Spawn(i);
        }
    }

    void Spawn(int i)
    {
        print("hiiiiii");
        Debug.Log("Spawin" + i);
        // print(i);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
