using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipFoot : MonoBehaviour
{
    // khai bao
    public SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            mySpriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)){
            mySpriteRenderer.flipX = false;
        }
    }
}
