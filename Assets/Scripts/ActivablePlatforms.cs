using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivablePlatforms : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public float speed = 2f;
    Vector2 targetPos;
    public ButtonActive boton;
    public ButtonActive boton2;

   
    void Start()
    {
        targetPos = endPos.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boton.isButtonActive || boton2.isButtonActive)
        {
        if(Vector2.Distance(transform.position, startPos.position)<.1f) targetPos = endPos.position;
       
        if(Vector2.Distance(transform.position, endPos.position)<.1f) targetPos = startPos.position;
       
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

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
