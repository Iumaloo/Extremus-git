using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMarino : MonoBehaviour
{
    public AudioSource myAudio;
    [SerializeField] AudioClip narrMarino;
    [SerializeField] AudioClip narrBlobFish;
    [SerializeField] AudioClip narrGusano;
    [SerializeField] AudioClip narrCalamar;
    [SerializeField] AudioClip narrCangrejo;

    public bool isYellin;
    void Update()
    {
        myAudio = GetComponent<AudioSource>();
    }
  
    void Start()
    {

    }

    // Update is called once per frame


    public void PlayMarino()
    {
        myAudio.PlayOneShot(narrMarino);
        isYellin = true;
    }
    public void PlayBlob()
    {
        myAudio.PlayOneShot(narrBlobFish);
        Debug.Log("BLOB SINGS");
    }
    public void PlayGusano()
    {
        myAudio.PlayOneShot(narrGusano);
    }
    public void PlayCangrejo()
    {
        myAudio.PlayOneShot(narrCangrejo);
    }
    public void PlayCalamar()
    {
        myAudio.PlayOneShot(narrCalamar);
    }
}
