using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class Shoot : MonoBehaviour
{
    public GameObject Bullet;

    public SpriteRenderer mySpriteRenderer;

    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
                anim.SetBool("shoot", true);

                Vector2 bulletPosition = new Vector2(ramboPosition.x + 1.5f, ramboPosition.y);
                Instantiate(Bullet, bulletPosition, Quaternion.identity);

                // Schedule the next step after another delay (0.2 seconds)
                Invoke("TurnOffAnimatorShoot", 0.2f);

            }
            else
            {
                anim.SetBool("shoot", true);

                Vector2 bulletPosition = new Vector2(ramboPosition.x - 1.5f, ramboPosition.y);
                Instantiate(Bullet, bulletPosition, Quaternion.identity);


                // Schedule the next step after another delay (0.2 seconds)
                Invoke("TurnOffAnimatorShoot", 0.2f);
            }
        }
    }

    void TurnOffAnimatorShoot()
    {
        anim.SetBool("shoot", false);
    }
}
