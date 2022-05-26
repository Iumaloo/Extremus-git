using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aver : MonoBehaviour
{
    Vector3 mouseposition;
    public float moveSpeed = 0.1f;
    Rigidbody rb;
    Vector2 position = new Vector2(0f, 0f);
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() 
    {
        mouseposition=Input.mousePosition;
        mouseposition=Camera.main.ScreenToWorldPoint(mouseposition);
        position=Vector2.Lerp(transform.position, mouseposition, moveSpeed);
    } 
    private void Fixed()
    {
        rb.MovePosition(position);
    }
}
