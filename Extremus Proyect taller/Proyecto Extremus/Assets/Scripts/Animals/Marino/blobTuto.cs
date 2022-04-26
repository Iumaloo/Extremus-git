using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobTuto : MonoBehaviour
{
    public Camera camera;
    public AudioMarino audios;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickAction();
    }
    public void BlobNarration()
    {
        Debug.Log("Blob");
        audios.PlayBlob();
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
                    Debug.Log("Blob caminaaa");

                    BlobNarration();
                }
            }
        }
    }
}
