using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptTar : MonoBehaviour
{
    public Camera camera;
    public ActiveNarra nar;
    public Audio1 audios;
    Animator animator;
    public Transform[] waypoints;
    private int waypointIndex;

    //Imagen En Pantalla
    public Image slot;
    public Sprite img;
    [SerializeField]
    float tiempoDesaparicion = 10f;

    private float dist;
    public int speed;
    public bool isPatrollin;
    public playerrotate rotateSmooth;
    public playermove _move;
    public playerrotate _rotate; Vector3 tmp;



    void Start()
    {
        animator = GetComponent<Animator>();
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        isPatrollin = false;
    }
    private void TarNarr()
    {
        Debug.Log("Este es el tardigradito");
        audios.PlayTar();
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
    void IncreaseSize()
    {
        tmp = transform.localScale;
        tmp.x += 7f;
        tmp.y += 7f;
        tmp.z += 7f;
        transform.localScale = tmp;
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
                    Debug.Log("Tar camina");
                    animator.SetBool("semueve", true);
                    TarNarr();
                    //Se asigna la imagen del animal y se pone el alpha en su maximo
                    //slot.sprite = img;
                   // Color clr = slot.color;
                   // clr.a = 255f;
                   // slot.color = clr;
                    //Funcion para limpiar el slot de la imagen despues de [tiempoDesaparicion] segudos
                    Invoke("ClearImage", tiempoDesaparicion);
                    IncreaseSize();
                    LimitAction();
                    Invoke("AllowAction", 18f);
                    isPatrollin = true;
                }
            }
        }
    }

   /* void ClearImage()
    {
        //Quita la referencia a la imagen y pone el aplha en su minimo
        slot.sprite = null;
        Color clr = slot.color;
        clr.a = 0f;
        slot.color = clr;
    }*/

}
