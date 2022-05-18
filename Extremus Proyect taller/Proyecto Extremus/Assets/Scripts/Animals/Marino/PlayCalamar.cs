using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayCalamar : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrMarino nar;
    public AudioMarino audios;
    public playerrotate rotateSmooth;
    public playermove _move;
    public playerrotate _rotate;
    Animator animator;
    public Transform[] waypoints;
     private int waypointIndex;
     private float dist;
     public int speed;
     public bool isPatrollin;

 
    Vector3 target;
    Vector3 _startingPos;
    Transform _trans;

    void Start()
    {
        animator = GetComponent<Animator>();
        //waypointIndex = 0;
        //transform.LookAt(waypoints[waypointIndex].position);
        isPatrollin = false;
        _trans = GetComponent<Transform>();
        _startingPos = _trans.position;


    }
    private void SquidNarration()
    {
        Debug.Log("Calamar");
        audios.PlayCalamar();
    }
    void Patrol()
    {
        if (isPatrollin == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Debug.Log("IT MOVES");
        }

    }
    void DontPatrol()
    {
        transform.Translate(Vector3.forward * 0 * Time.deltaTime);
        Debug.Log("troste");
    }
    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);//error index outside bounds of array preguntar.
    }
    public void LimitAction()
    {
        _move._speed = 0;
        _rotate.speed = 0;
        rotateSmooth.speed = 0;
    }
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        if (!audios.myAudio.isPlaying)
        {
            Debug.Log("Paró narración");
            ClickAction();
        }

        if (dist < 1f)
        {
            IncreaseIndex();
        }
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        //con bools
        Patrol();
        if(isPatrollin==true)
        {
            MoveVertical();
        }
        
    }
    public void MoveVertical()
    {
        _trans.position = new Vector3(_startingPos.x, _startingPos.y + Mathf.PingPong(Time.time, 3), _startingPos.z);
    }
    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if ((Physics.Raycast(ray, out hit, 100.0f)))
            {
                if (hit.transform != null)
                {
                    animator.SetBool("semueve", true);
                    Debug.Log("Calamar camina"); 
                    SquidNarration();
                   
                     isPatrollin = true;
                }
            }
        }
    }
}
