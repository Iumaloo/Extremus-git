using System.Collections;
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

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        isPatrollin = false;
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


    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetP>() != null)
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
        tmp.x += 4f;
        tmp.y += 4f;
        tmp.z += 4f;
        transform.localScale = tmp;
    }
}
