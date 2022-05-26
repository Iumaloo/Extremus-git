using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionPhysics1 : MonoBehaviour {

    [SerializeField] private float mass=2;
    [SerializeField] float gravedad;

    Vector3 acceleration;
    Vector3 displacement;
    [SerializeField]
    Vector3 velocity;
    [SerializeField] float xBorder, yBorder;
    [SerializeField] float dampfactor;
    [SerializeField] float coeficiente;
    float frontalArea;
    




    void Start()
    {
        frontalArea = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //ApplyForce(new Vector3(0, -5, 0));
        //ApplyForce(new Vector3(2, 0, 0));
        ApplyForce(new Vector3(0, mass * gravedad, 0));
        //ApplyForce(-coeficiente * velocity.normalized);
        ApplyForce(-0.5f* (velocity.magnitude * velocity.magnitude * frontalArea* coeficiente * velocity.normalized));
        
        
        //force = mass * gravedad - acceleration.normalized * coeficiente;

        Move();
        CheckCollisions();
        acceleration = Vector3.zero;
    }
    public void Move()
    {
        

        velocity += acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;

        transform.position = transform.position + displacement;
        //if (transform.position.y <= -5)
        //{
        //    velocity *= -0.9f;
        //}
        //Debug vectors


       // acceleration.Draw(transform.position, Color.blue);
        //velocity.Draw(transform.position, Color.green);
        //transform.position.Draw(Color.red);
    }
    private void CheckCollisions()
    {
        if (transform.position.x >= xBorder || transform.position.x <= -xBorder)

        {
            if (transform.position.x >= xBorder) transform.position = new Vector3(xBorder, transform.position.y, 0);
            else if (transform.position.x <= -xBorder) transform.position = new Vector3(-xBorder, transform.position.y, 0);
            velocity.x = velocity.x * -1;
            velocity *= dampfactor;
        }
        if (transform.position.y >= yBorder || transform.position.y <= -yBorder)

        {
            if (transform.position.y >= yBorder) transform.position = new Vector3(transform.position.x, yBorder, 0);
            else if (transform.position.y <= -xBorder) transform.position = new Vector3(transform.position.x, -yBorder, 0);
            velocity.y = velocity.y * -1;
            velocity *= dampfactor;
        }
    }
    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
        
    }
}

