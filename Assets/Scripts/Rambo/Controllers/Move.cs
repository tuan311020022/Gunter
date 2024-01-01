using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // sang trai = -1, sang phai = 1
    public float diChuyen;
    public float tocDo = 2;
    public float rotationSpeed = 200;
    public float mau = 100;
    public SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        mySpriteRenderer.flipX = false;
    }

    // Update is called once per frame
    void Update()
    {
        // an nut sang phai
        if (Input.GetKey(KeyCode.RightArrow)){
            // Vector2.right = (1,0)
            transform.Translate(Vector2.right * tocDo * Time.deltaTime);
            mySpriteRenderer.flipX = false;

        } else if (Input.GetKey(KeyCode.LeftArrow)) // an nut sang trai
        {
            //Vector2.left = (-1,0)
            transform.Translate(Vector2.left * tocDo * Time.deltaTime);
            mySpriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            // Vector2.up = (0,1)
            transform.Translate(Vector2.up * 20 * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow)){
            // Vector2.down = (0,-1)
            transform.Translate(Vector2.down * tocDo * Time.deltaTime);
        }
    }

    public string GetTranslate()
    {
        return "hello";
    }
}
