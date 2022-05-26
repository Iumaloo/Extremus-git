using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {
    [SerializeField]
    [Range(0,10)]

    float rapidez;
    //Vector3 acceleration;
    Vector3 displacement;
    Vector3 velocity;
    [SerializeField] float xBorder, yBorder;
    //[SerializeField] float dampfactor;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CheckCollisions();
    }
    public void Move()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diferecia = mousePos - transform.position;
        if (diferecia.magnitude < 0.3)
        {
            return;
        }

        float radians = Mathf.Atan2(diferecia.y, diferecia.x);
        velocity = diferecia.normalized * rapidez;
        //velocity += acceleration * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, 0f, radians * Mathf.Rad2Deg);


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
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        worldPos.z = 0;
        return worldPos;
    }
    private void CheckCollisions()
{
    if (transform.position.x >= xBorder || transform.position.x <= -xBorder)

    {
        if (transform.position.x >= xBorder) transform.position = new Vector3(xBorder, transform.position.y, 0);
        else if (transform.position.x <= -xBorder) transform.position = new Vector3(-xBorder, transform.position.y, 0);
        velocity.x = velocity.x * -1;
        //velocity *= dampfactor;
    }
    if (transform.position.y >= yBorder || transform.position.y <= -yBorder)

    {
        if (transform.position.y >= yBorder) transform.position = new Vector3(transform.position.x, yBorder, 0);
        else if (transform.position.y <= -xBorder) transform.position = new Vector3(transform.position.x, -yBorder, 0);
        velocity.y = velocity.y * -1;
        //velocity *= dampfactor;
    }
}

}
