using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menupausa;
    private bool juegoPausado=false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado==false)
            {
                Pausa();
            }
            else if(juegoPausado==true)
            {
                Reanudar();
            }
            
        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menupausa.SetActive(true);
        
    }
    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menupausa.SetActive(false);
    }
    public void Configuracion()
    {
        juegoPausado=false;
        SceneManager.LoadScene("Configuración");
    }
    public void cerrar()
    {
        SceneManager.LoadScene("Islas");
        //Application.Quit(); 
    }
    public void LoadScene(string scenemane)
    {
        SceneManager.LoadScene(scenemane);
    }
}
