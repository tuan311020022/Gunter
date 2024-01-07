// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class E3 : EnemyController
// {
//     #region Public

//     // public Transform playerCheck;
//     public float playerCheckRadius = 0.1f;
//     public LayerMask playerLayer;
//     public Vector2 currentPos;
//     #endregion

//     void Start()
//     {
//         anim = GetComponent<Animator>();
//         rb2D = GetComponent<Rigidbody2D>();

//         currentPos = GetComponent<Transform>().position;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Move();
//         FlipWhenSpottedPlayer(player.position.x - transform.position.x);
//     }

//     void Move()
//     {
//         if(Physics2D.OverlapCircle(transform.position, playerCheckRadius, playerLayer))
//         {
//             //detectPlayer = true;
//             anim.SetBool("Walk", true);
//             transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
//         }
//         else{
//             //detectPlayer = false;
//             transform.position = Vector2.MoveTowards(transform.position, currentPos, moveSpeed * Time.deltaTime);
//             anim.SetBool("Walk", false);
//         }
//     }
    

//     private void OnCollisionEnter2D(Collision2D other) {
//         if(other.gameObject.CompareTag("Obstacle"))
//         {
//             Flip();
//         }
//     }

//     private void OnDrawGizmosSelected() {
//       Gizmos.color = Color.green;
//       Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
//     }
// }
