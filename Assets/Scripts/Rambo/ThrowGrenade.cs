using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenade;

    public SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector2 ramboPosition = mySpriteRenderer.transform.position;

            if (mySpriteRenderer.flipX == false)
            {
                Vector2 bulletPosition = new Vector2(ramboPosition.x + 1.5f, ramboPosition.y);
                Instantiate(grenade, bulletPosition, Quaternion.identity);
            }
            else
            {
                Vector2 bulletPosition = new Vector2(ramboPosition.x - 1.5f, ramboPosition.y);
                Instantiate(grenade, bulletPosition, Quaternion.identity);
            }
        }
    }
}
