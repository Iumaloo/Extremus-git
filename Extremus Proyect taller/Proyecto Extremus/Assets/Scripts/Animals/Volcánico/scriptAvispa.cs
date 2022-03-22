﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAvispa : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrNuclear nar;
    public AudioNucl audios;
    Animator animator;
 

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
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



    }

    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetA>() != null)
                {
                    Debug.Log("La araña camina");
                    animator.SetBool("semueve", true);
                    WaspNarration();
                }
            }
        }
    }
}
