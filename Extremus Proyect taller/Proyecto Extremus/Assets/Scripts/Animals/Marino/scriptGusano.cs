using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptGusano : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrMarino nar;
    public AudioMarino audios;
    Animator animator;
    public Transform[] waypoints;
    public int speed;
    private int waypointIndex;
    private float dist;
    public bool isPatrollin;
    void Start()
    {
        animator = GetComponent<Animator>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);

        isPatrollin = false;
    }
    private void WormNarration()
    {
        Debug.Log("Gusano");
        audios.PlayGusano();
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
        transform.LookAt(waypoints[waypointIndex].position);
    }
    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetC>() != null)
                {
                    Debug.Log("gusano camina");

                    animator.SetBool("semueve", true);
                    WormNarration();
                    isPatrollin = true;
                }
            }
        }
    }
}
