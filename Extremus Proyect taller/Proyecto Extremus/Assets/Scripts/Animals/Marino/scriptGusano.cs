﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptGusano : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrMarino nar;
    public AudioMarino audios;
    Animator animator;
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
            RaycastHit hit;
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if ((Physics.Raycast(ray, out hit)))
            {
                if (hit.transform.name=="gusanor")
                {
                    Debug.Log("gusano camina");

                    animator.SetBool("semueve", true);
                    WormNarration();
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
