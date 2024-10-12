using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class touchingDirections : NetworkBehaviour
{
    public ContactFilter2D castFilter;
    public CapsuleCollider2D col;
    public float groundDistance = 0.05f;
    public bool isGround { get {
        return _isGround;
    } private set
    {
        _isGround = value;
    } }
    
    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    private bool _isGround; 

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
    }
   

    // Update is called once per frame
    void FixedUpdate()
    {
         isGround = col.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
    }

    
}
