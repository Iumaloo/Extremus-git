using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate : MonoBehaviour
{
    [SerializeField] GameObject Bien;
    [SerializeField] GameObject textoWalk;
    [SerializeField] GameObject btnWalk;
    [SerializeField] GameObject btnBien;

    public playermove playermove;
    public playerrotate playerrotate;
    public PlayerRotateSmooth playerSmooth;
    float timer;
    //El usuario llega a la isla y los primeros mensajes estarán activados
    //Primero se muestra un mensaje de introducción, a los 7 segundos pasa a otro texto
    //es enseñarle a como usar wasd
    //enseñarle a rotar
    //a clickear una rata
    //listo
    // Start is called before the first frame update
    void Start()
    {
        playermove._speed = 0;
        playerrotate.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
       /* timer += Time.deltaTime;
        ShowFirstText();

        // Debug.Log("tIMR :" + timer);*/
    }


    /*void ShowFirstText()
    {
        activations[0].SetActive(true);
        if (timer > 5)
        {

            activations[0].SetActive(false);
            activations[1].SetActive(true);

            if (timer >= 8)
            {
                activations[1].SetActive(false);
                playermove._speed = 10;
            }

        }
    }
    void HideFirstText()
    {

    }

    void ShowSecondText()
    {
        activations[1].SetActive(true);
        if (Time.deltaTime >= 5.0f)
        {
            Destroy(activations[1]);
        }
    }*/

    public void ActivateCaminar()
    {
        //por defeteco aparecerá el primer texto y el bótón
        //al presionar el botón se desactivará el texto actual y se activará el siguiente, y el botón actual se desactiva tambien
        Bien.SetActive(false);//textoBienv
    
        textoWalk.SetActive(true);//activar texto caminar
        btnWalk.SetActive(true);//activar botón walk para luego rotar
        //textoWalk.SetActive(false);//botónseguiracamniar
        btnBien.SetActive(false);

        Walk();

    }

    public void Walk()
    {
        playermove._speed = 10;
    }

  /* public  void ActivateRotate()
    {
        .SetActive(false);//desactivar texto caminar
        activations2[1].SetActive(false);//desactivar botón walks
        activations2[2].SetActive(true); //activar texto rotar
        activations2[3].SetActive(true); //activar boton rotar
        playerrotate.speed = 200;
        playerSmooth.speed = 200;
    }*/

    
}
