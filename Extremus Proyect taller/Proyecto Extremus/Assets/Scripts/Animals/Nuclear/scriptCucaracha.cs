using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptCucaracha : MonoBehaviour
{
    public Camera camera;
    public ActiveNarrNuclear nar;

    //Imagen En Pantalla
    public Image slot;
    public Sprite img;
    [SerializeField]
    float tiempoDesaparicion = 10f;
    public AnimationClip animClip;

    public AudioNucl audios;
    Animator animator;
  


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void RoachNarration()
    {
        Debug.Log("cucaracha");
        audios.PlayC();
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
                    Debug.Log("la cucaracah camina");

                    animator.SetBool("semueve", true);
                    RoachNarration();

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
