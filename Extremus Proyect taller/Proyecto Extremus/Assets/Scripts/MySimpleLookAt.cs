using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleLookAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = GetWorldMousePosition();
        Vector3 mousePos = GetWorldMousePosition();
        //float slope = mousePos.y / mousePos.x;
        //float radians = Mathf.Atan(slope);
        Vector3 diferecia = mousePos-transform.position ;
        float radians = Mathf.Atan2(diferecia.y, diferecia.x);
        //float radians = Mathf.Atan2(mousePos.y, mousePos.x);
        transform.localRotation = Quaternion.Euler(0f, 0f, radians* Mathf.Rad2Deg);


        Debug.DrawLine(Vector3.zero, transform.position);

	}
    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        worldPos.z = 0;
        return worldPos;
    }
}
