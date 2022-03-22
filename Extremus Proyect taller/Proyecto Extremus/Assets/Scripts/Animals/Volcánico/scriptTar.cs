﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptTar : MonoBehaviour
{
    public Camera camera;
    public ActiveNarra nar;
    public Audio1 audios;
    Animator animator;
 

    void Start()
    {
        animator = GetComponent<Animator>();
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
    }

    public void ClickAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray goes through camera to position in the world the mouse points
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<TargetC>() != null)
                {
                    Debug.Log("Tar camina");
                    animator.SetBool("semueve", true);
                    TarNarr();
                }
            }
        }
    }
}
