using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawn;
    private Rigidbody2D my_rigidbody; 
    private CircleCollider2D my_collider;
    private float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
        my_collider = GetComponent<CircleCollider2D>();
        ChooseStartDirection();
        GameManager.Instance.StartGame();
        GameManager.Instance.Victory += Victory;
        GameManager.Instance.ResetGame += ResetGame;
    }

    private void ChooseStartDirection()
    {
        int i = 0;

        if (UnityEngine.Random.value < 0.5f)
            i = 1;
        else
            i = -1;
      
        my_rigidbody.velocity = new Vector2(speed * i, 0);
    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        GameManager.Instance.PlaySound();
        if (my_rigidbody.velocity.y == 0)
            my_rigidbody.AddForce(new Vector2(0, UnityEngine.Random.Range( -speed, speed )));
   }
   void OnBecameInvisible()
   {
       if(GameManager.Instance != null)
       {
            if(transform.position.x > 0)
            {
                GameManager.Instance.GivePoint(true);
            }
            else
            {
                GameManager.Instance.GivePoint(false);
            }
       }
       
       transform.position = spawn;
       my_rigidbody.velocity = new Vector2(-my_rigidbody.velocity.x, 0);
   }

   private void Victory(object sender, EventArgs e)
   {
       gameObject.SetActive(false);
   }
   private void ResetGame(object sender, EventArgs e)
   {
       gameObject.SetActive(true);
       ChooseStartDirection();
   }
}
