using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    //Imagen En Pantalla
    public Image slot;
    public Sprite img;
    [SerializeField]
    float tiempoDesaparicion = 10f;
    public AnimationClip animClip;
    private int waypointIndex;
     private float dist;
     public int speed;
     public bool isPatrollin;
    public float rayLength;
    public LayerMask layermask;

 
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
   /* void Patrol()
    {
        if (isPatrollin == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Debug.Log("IT MOVES");
        }

    }*/
    void DontPatrol()
    {
        transform.Translate(Vector3.forward * 0 * Time.deltaTime);
        Debug.Log("troste");
    }
   /* void IncreaseIndex()
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);//error index outside bounds of array preguntar.
    }*/
    public void LimitAction()
    {
        _move._speed = 0;
        _rotate.speed = 0;
        rotateSmooth.speed = 0;
    }
    void Update()
    {
       /* transform.localEulerAngles = new Vector3(0, 0, 0);
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
        Patrol();*/
        if(isPatrollin==true)
        {
            MoveVertical();
            Debug.Log("WUWUW");
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
            Debug.Log("ya hizo click");
            RaycastHit hit;
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if ((Physics.Raycast(ray, out hit,100.0f)))
            {
                Debug.Log("raycast");
                if (hit.transform!=null)
                {
                    Debug.Log("es nulo");
                    animator.SetBool("semueve", true);
                    Debug.Log("Calamar camina"); 
                    SquidNarration();

                    //Se invoca la muestra de image despues de a duracion del clip
                    Invoke("DisplayImage", animClip.length);

                    isPatrollin = true;


                }
            }
        }
    }

    void DisplayImage()
    {
        //Se asigna la imagen del animal y se pone el alpha en su maximo
        slot.sprite = img;
        Color clr = slot.color;
        clr.a = 255f;
        slot.color = clr;
        //Funcion para limpiar el slot de la imagen despues de [tiempoDesaparicion] segudos
        Invoke("ClearImage", tiempoDesaparicion);
    }

    void ClearImage()
    {
        //Quita la referencia a la imagen y pone el aplha en su minimo
        slot.sprite = null;
        Color clr = slot.color;
        clr.a = 0f;
        slot.color = clr;
    }
}
