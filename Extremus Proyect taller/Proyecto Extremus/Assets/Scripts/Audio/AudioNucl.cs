using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioNucl : MonoBehaviour
{
    // public Sounds[] sounds;
    public AudioSource myAudio;
    [SerializeField] AudioClip narrNuc;
    [SerializeField] AudioClip narrAvispa;
    [SerializeField] AudioClip narrRana;
    [SerializeField] AudioClip narrPuma;
    [SerializeField] AudioClip narrCucaracha;

    public bool isYellin;
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


    public void PlayNucl()
    {
        myAudio.PlayOneShot(narrNuc);
        isYellin = true;
    }
    public void PlayAvispa()
    {
        myAudio.PlayOneShot(narrAvispa);
    }
    public void PlayRana()
    {
        myAudio.PlayOneShot(narrRana);
    }
    public void PlayPuma()
    {
        myAudio.PlayOneShot(narrPuma);
    }
    public void PlayC()
    {
        myAudio.PlayOneShot(narrCucaracha);
    }
    public void CheckSound()
    {
        if (!myAudio.isPlaying)
        {
            isYellin = false;
        }
    }
}

