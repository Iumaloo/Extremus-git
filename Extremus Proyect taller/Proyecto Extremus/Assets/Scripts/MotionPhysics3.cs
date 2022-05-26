using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionPhysics3 : MonoBehaviour {

    [SerializeField] private float mass = 2;
    [SerializeField] float gravedad;
    [SerializeField]
    MotionPhysics3 other;

    Vector3 acceleration;
    [SerializeField]
    Vector3 velocity;
    Vector3 displacement;
    float MaxForce=5f;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 r = other.transform.position-transform.position;

        //ApplyForce(new Vector3(0, -5, 0));
        //ApplyForce(new Vector3(2, 0, 0));
        //ApplyForce(new Vector3(0, mass * gravedad, 0));
        //ApplyForce(-coeficiente * velocity.normalized);
        //ApplyForce(-0.5f * (velocity.magnitude * velocity.magnitude * frontalArea * coeficiente * velocity.normalized));

        //Atraccion Gravitacional
        ApplyForce(mass*other.mass*r.normalized/(r.magnitude*r.magnitude));


        //force = mass * gravedad - acceleration.normalized * coeficiente;
        //Vector3 myForce =;
        Move();
       

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


        //acceleration.Draw(transform.position, Color.blue);
        //velocity.Draw(transform.position, Color.green);
        //transform.position.Draw(Color.red);
    }
    
    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;

    }
}