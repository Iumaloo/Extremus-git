using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveNarrNuclear : MonoBehaviour
{
    public AudioNucl audio;
    public bool isTalking;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NucNarr()
    {
        isTalking = true;
        Debug.Log("Empieza Narración Nuclear");
        audio.PlayNucl();

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here it is");

        NucNarr();
        isTalking = false;

    }
}
