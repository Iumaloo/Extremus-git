using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCaracol : MonoBehaviour
{
    public Camera camera;
    public Audio1 audio;
    public  ActiveNarra nar;
    public playerrotate rotateSmooth;
    public playermove _move;
    public playerrotate _rotate;
    Animator animator;
    /*private void OnMouseDown()
    {
        Debug.Log("El caracol se muueeveee");
        SnailNarration();
    }*/
    public Transform[] waypoints;
    //Imagen En Pantalla
    public Image slot;
    public Sprite img;
    [SerializeField]
    float tiempoDesaparicion = 10f;
    public AnimationClip animClip;
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
    private void SnailNarration()
    {
        Debug.Log("Tiene un caparazón de sulfuro...");
        audio.PlaySnail();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);

        isPatrollin = false;
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
        transform.LookAt(waypoints[waypointIndex].position);//error index outside bounds of array preguntar.
    }
    public void LimitAction()
    {
        _move._speed = 0;
        _rotate.speed = 0;
        rotateSmooth.speed = 0;
    }
    public void AllowAction()
    {
        _move._speed = 10;
        _rotate.speed = 200;
        rotateSmooth.speed = 200;
    }
    void ClickAction()
    {
        //CUANDO EL USUARIO CLICKEE EL CLICK IZQUIERDO SE ACTIVARÁ LA ACCIÓN DE QUE EL CARACOL SE MUEVA
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetR>() != null)
                {
                    Debug.Log("El caracol se muueeveee");
                    animator.SetBool("semueve", true);
                    SnailNarration();
                    LimitAction();
                    Invoke("AllowAction", 18f);
                    isPatrollin = true;

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
