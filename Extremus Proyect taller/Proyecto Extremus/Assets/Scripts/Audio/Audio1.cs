using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class Audio1 : MonoBehaviour
{
    //ESTE SCRIPT ES DEL VOLCÁN
    // public Sounds[] sounds;
    public AudioSource myAudio;
    [SerializeField] AudioClip narrVol;
    [SerializeField] AudioClip narrSpider;
    [SerializeField] AudioClip narrBird;
    [SerializeField] AudioClip narrSnail;
    [SerializeField] AudioClip narrTar;

    public bool isVol, isBird,isTard,isSpi,isSnail,isYellin;
    
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.C))
        {
            myAudio.PlayOneShot(narrVol);
        }*/
        myAudio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    /*void Awake()
     {
         foreach(Sounds s in sounds)
         {
             s.myAudio=gameObject.AddComponent<AudioSource>();
             s.myAudio.clip = s.clip;
             s.myAudio.volume = s.volume;
         }

     }*/

    /*public void Play (string name)
     {
        Sounds s= Array.Find(sounds, sound => sound.name == name);
         s.myAudio.Play();
     }*/
    void Start()
    {
     
    }

    // Update is called once per frame
    
    public void PlayTar()
    {
        myAudio.PlayOneShot(narrTar);
    }
    public void PlayVolcan()
    {
        myAudio.PlayOneShot(narrVol);
        isYellin = true;
    }
    public void PlaySpider()
    {
        myAudio.PlayOneShot(narrSpider);
    }
    public void PlayBird()
    {
        myAudio.PlayOneShot(narrBird);
    }
    public void PlaySnail()
    {
        myAudio.PlayOneShot(narrSnail);
    }
    public void CheckSound()
    {
        if(!myAudio.isPlaying)
        {
            isYellin = false;
        }
    }
}
