using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dog : MonoBehaviour
{
    public UnityEvent takeSpikeEvent;
    public UnityEvent takeCoinEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Spike>())
            takeSpikeEvent?.Invoke();
        
        if(other.gameObject.GetComponent<Coin>())
            takeCoinEvent?.Invoke();
    }
    
    [SerializeField] private float forceJump = 1;


    private Rigidbody2D rb;
    private Move move;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Spike>())
            takeSpikeEvent?.Invoke();

        if (collision.gameObject.GetComponent<Ground>())
            move.CanJump = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
            move.CanJump = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<Move>();
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
    }
    
}
