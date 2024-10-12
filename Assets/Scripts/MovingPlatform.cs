using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class MovingPlatform : NetworkBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed = 2f;
    Vector2 targetPos;
    void Start()
    {
        targetPos = endPos.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(transform.position, startPos.position)<.1f) targetPos = endPos.position;
       
       if(Vector2.Distance(transform.position, endPos.position)<.1f) targetPos = startPos.position;
       
       transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos.position, endPos.position);
    }
}
