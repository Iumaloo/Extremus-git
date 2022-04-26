using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPuma : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrNuclear nar;
    public AudioNucl audios;
    public Transform[] waypoints;
    Animator animator;
    private int waypointIndex;
    private float dist;
    public int speed;
    public bool isPatrollin;
    // Audio1 audio;
    /*private void OnMouseDown()
    {
       Debug.Log("La araña camina");
        SpiderNarration();
    }*/

    void Start()
    {
        animator = GetComponent<Animator>();
       
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        isPatrollin = false;
    }
    private void PumaNarration()
    {
        Debug.Log("PUMA");
        audios.PlayPuma();
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
                if (hitInfo.collider.gameObject.GetComponent<TargetR>() != null)
                {
                    Debug.Log("el puma camina");
                    animator.SetBool("semueve", true);
                    PumaNarration();
                    isPatrollin = true;
                }
                
            }
        }

        //Invoke("StopAnimation", 20);
    }

    public void StopAnimation()
    {
        animator.SetBool("semueve", false);

    }
}
