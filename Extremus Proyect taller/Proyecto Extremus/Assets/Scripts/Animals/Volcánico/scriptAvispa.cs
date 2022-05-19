﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAvispa : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrNuclear nar;
    public AudioNucl audios;
    Animator animator;
    public Transform[] waypoints;
    private int waypointIndex;
    private float dist;
    public int speed;
    public bool isPatrollin;
    Vector3 tmp;
    //true vertical shit
    Vector3 _startingPos;
    Transform _trans;

    void Awake()
    {
        animator =GetComponent<Animator>();
       /* waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);*/
        isPatrollin = false;
        _trans = GetComponent<Transform>();
        _startingPos = _trans.position;
    }
    private void WaspNarration()
    {
        Debug.Log("Avispa");
        audios.PlayAvispa();
    }
    void Update()
    {
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
        if (isPatrollin == true)
        {
            MoveVertical();
        }
    }
    public void MoveVertical()
    {
        _trans.position = new Vector3(_startingPos.x, _startingPos.y + Mathf.PingPong(Time.time, 3), _startingPos.z);
    }
    void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
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

    /*public void MoveVertical()
    {
        _trans.position = new Vector3(_startingPos.x, _startingPos.y + Mathf.PingPong(Time.time, 3), _startingPos.z);
    }*/
    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,50.0f))
            {
                if (hit.transform.tag=="avispa")
                {
                    Debug.Log("La araña camina");
                    animator.SetBool("semueve", true);
                    WaspNarration();
                    isPatrollin = true;
                    IncreaseSize();
                }
            }
        }
    }

    void IncreaseSize()
    {
        tmp = transform.localScale;
        tmp.x += 1.2f;
        tmp.y += 1.2f;
        tmp.z += 1.2f;
        transform.localScale = tmp;
    }
}
