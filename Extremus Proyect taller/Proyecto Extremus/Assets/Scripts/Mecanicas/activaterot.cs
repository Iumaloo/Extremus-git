﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activaterot : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    public playerrotate playerrotate;
    public PlayerRotateSmooth playsmooth;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     
        timer += Time.deltaTime;
       // Debug.Log("T : " + timer);
        foreach (GameObject textos in objects)
        {

            if (textos.tag == "orbitar")
            {
              
                if (timer >=4)
                {
                    textos.SetActive(false);
                  
                }
            }
        }


    }
    void OnTriggerEnter(Collider other)
    {
        timer = 0;
        if (other.tag == "player")
        {
            
            Debug.Log("DD");
           /* for (int i=0;i<objects.Length;i++)
            {
                if (objects[i].CompareTag("orbitar"))
                {
                    Debug.Log("dddddd");
                    objects[i].SetActive(true);
                }
            }*/
            foreach (GameObject textos in objects)
            {
                
                if (textos.CompareTag("orbitar"))
                {
                    
                    textos.SetActive(true);
                    Debug.Log("active");
                    playerrotate.speed = 200;
                    playsmooth.speed = 200;
                }
            }
        }
         
    }
    
}