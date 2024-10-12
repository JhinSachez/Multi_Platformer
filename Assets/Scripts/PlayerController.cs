using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    public float walkSpeed = 5.0f;
    private Vector2 moveInput;
    private bool IsMoving;
    public float jumpImpulse = 10.0f;
    Rigidbody2D rb;
    touchingDirections touchingdirections;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingdirections = GetComponent<touchingDirections>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public override void OnStartNetwork()
    {
        if (Owner.IsLocalClient)
        {
            name += "(local)";
            GetComponent<SpriteRenderer>().material.color = Color.green;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (IsOwner == false)
        {
            return;
        }
        
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        
        IsMoving = moveInput != Vector2.zero;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (IsOwner == false)
        {
            return;
        }
        
        if (context.started && touchingdirections.isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Caida"))
        {
            transform.position = new Vector2(-14.86f, -1.88f);
        }
    }
}
