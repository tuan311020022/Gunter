using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;

    public SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Vector2 ramboPosition = mySpriteRenderer.transform.position;

            if (mySpriteRenderer.flipX == false)
            {
                Vector2 bulletPosition = new Vector2(ramboPosition.x + 1.5f, ramboPosition.y);
                Instantiate(Bullet, bulletPosition, Quaternion.identity);
            }
            else
            {
                Vector2 bulletPosition = new Vector2(ramboPosition.x - 1.5f, ramboPosition.y);
                Instantiate(Bullet, bulletPosition, Quaternion.identity);
            }
        }
    }
}
