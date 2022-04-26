using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptRana : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrNuclear nar;
    public AudioNucl audios;
    Animator animator;
    // Audio1 audio;
    /*private void OnMouseDown()
    {
       Debug.Log("La araña camina");
        SpiderNarration();
    }*/

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void FrogNarration()
    {
        Debug.Log("Rana");
        audios.PlayRana();
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
                    animator.SetBool("semueve", true);
                    Debug.Log("La araña camina");

                    FrogNarration();
                }
            }
        }
    }
}
