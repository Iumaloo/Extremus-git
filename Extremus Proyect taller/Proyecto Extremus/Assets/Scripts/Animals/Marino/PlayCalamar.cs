using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayCalamar : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrMarino nar;
    public AudioMarino audios;
    Animator animator;
    /* public Transform[] waypoints;
     private int waypointIndex;
     private float dist;
     public int speed;
     public bool isPatrollin;*/
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;


    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

    }
    private void SquidNarration()
    {
        Debug.Log("Calamar");
        audios.PlayCalamar();
    }
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        if (!audios.myAudio.isPlaying)
        {
            Debug.Log("Paró narración");
            ClickAction();
        }

        if(Vector3.Distance(transform.position,target)<1)
        {

        }
       



    }
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex==waypoints.Length)
        {
            waypointIndex = 0;
        }
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
                    animator.SetBool("semueve", true);
                    Debug.Log("Calamar camina"); 
                    SquidNarration();
                    
                }
            }
        }
    }
}
