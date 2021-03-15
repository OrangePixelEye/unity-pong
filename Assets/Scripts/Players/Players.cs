using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Players : MonoBehaviour
{
    protected Rigidbody2D my_rigidbody;
    [Range(10f,500f)]
    [SerializeField]
    protected float speed = 12f;

    protected void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
    }
    public abstract void HandleInput();
    protected void MoveBar(int vertical)
    {
        my_rigidbody.velocity = new Vector2(0, vertical * speed);
    }

    protected void Update()
    {
        HandleInput();
    }
}