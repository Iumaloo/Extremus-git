using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOrbital : MonoBehaviour {

    
    Vector3 acceleration;
    Vector3 displacement;

    [SerializeField]
    [Range(0, 10)]
    float rapidez;
    
    Vector3 velocity;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
        
    }
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        worldPos.z = 0;
        return worldPos;
    }
    public void Move()
    {
        Vector3 mousePos = GetWorldMousePosition();
        Vector3 diferecia = mousePos - transform.position;
        float radians = Mathf.Atan2(velocity.y, velocity.x);


        acceleration = diferecia;
        velocity += acceleration * Time.deltaTime;
        displacement = velocity * Time.deltaTime;
        transform.position += displacement;
        transform.localRotation = Quaternion.Euler(0,0,radians*Mathf.Rad2Deg);
    }
}
