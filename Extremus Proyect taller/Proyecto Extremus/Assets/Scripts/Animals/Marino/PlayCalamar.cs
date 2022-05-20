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
  /*  public float rayLength;
    public LayerMask layermask;*/

 
    Vector3 target;
    Vector3 _startingPos;
    Transform _trans;

    void Start()
    {
        animator = GetComponent<Animator>();
      
        isPatrollin = false;
        _trans = GetComponent<Transform>();
        _startingPos = _trans.position;


    }
    private void SquidNarration()
    {
        Debug.Log("Calamar");
        audios.PlayCalamar();
    }
 
  
    public void LimitAction()
    {
        _move._speed = 0;
        _rotate.speed = 0;
        rotateSmooth.speed = 0;
    }
    void Update()
    {
        if (!audios.myAudio.isPlaying)
        {
            Debug.Log("Paró narración");
            ClickAction();
        }
        if (isPatrollin==true)
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
         
            Debug.Log("ya hizo click al pulpooo");
            RaycastHit hit;
            
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
           
            if (Physics.Raycast(ray, out hit, 50.0f))
            {
                Debug.Log("hit name:"+ hit.transform.name);
                Debug.Log("raycast fffff");
                if (hit.transform.tag == "pulpo")
                {
                    
                    isPatrollin = true;
                    Debug.Log("es nulo");
                    animator.SetBool("semueve", true);
                    Debug.Log("Calamar camina"); 
                    SquidNarration();

                    //Se invoca la muestra de image despues de a duracion del clip
                    Invoke("DisplayImage", animClip.length);

                 


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
