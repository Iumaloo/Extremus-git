using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPajaro : MonoBehaviour
{
    public Camera camera;
    public Audio1 audio;
    Animator animator;
    public Transform[] waypoints;
    private int waypointIndex;
    private float dist;
    public int speed;
    public bool isPatrollin;
    /* private void OnMouseDown()
     {
         Debug.Log("El pájaro camina/Aletea)");
         BirdNarration();
     }*/

    void Start()
    {
        animator = GetComponent<Animator>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        isPatrollin = false;
    }
    private void BirdNarration()
    {
        Debug.Log("Este  párajo con grandes patas...");
        audio.PlayBird();
    }

    void Update()
    {
        if (!audio.myAudio.isPlaying)
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

    void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetP>() != null)
                {
                    Debug.Log("El pájaro camina/Aletea");
                    animator.SetBool("semueve", true);
                    BirdNarration();
                    isPatrollin = true;
                }
            }
        }
    }
}
