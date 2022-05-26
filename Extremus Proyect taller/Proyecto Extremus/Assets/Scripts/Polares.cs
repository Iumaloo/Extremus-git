using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polares : MonoBehaviour {
    
    [SerializeField]
    Vector2 polarCoord; //x is radius, y is angle
    [SerializeField]
    int angularspeed;
    [SerializeField]
    int radialSpeed;
    [SerializeField]

    int acceleracionR;
    [SerializeField]

    int accelerationu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
        polarCoord.y += angularspeed*Time.deltaTime*acceleracionR;
        
        polarCoord.x += radialSpeed*Time.deltaTime*accelerationu;
        
        transform.localPosition = PolarToCartesian(polarCoord);
        Drawpolar(polarCoord);
        if (Mathf.Abs(polarCoord.x) >5)
        {
            radialSpeed = radialSpeed*(-1);
        }
        
    }
    private void Drawpolar(Vector2 polarCoord)
    {
        Vector3 cartesian = PolarToCartesian(polarCoord);
        Debug.DrawLine(Vector3.zero, cartesian, Color.yellow);
    }
    private Vector3 PolarToCartesian(Vector2 polar)
    {
        float r = polarCoord.x;
        float theta = polarCoord.y;
        float cos = Mathf.Cos(polarCoord.y);
        float sin = Mathf.Sin(polarCoord.y);
        Vector3 cartesian = new Vector3(cos, sin);
        cartesian *= r;
        return cartesian;
    }
}
