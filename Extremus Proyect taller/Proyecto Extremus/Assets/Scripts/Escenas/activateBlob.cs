using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateBlob : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject textOrbitar;
    [SerializeField] GameObject fishObjec;
    [SerializeField] GameObject btnBeforeBob;
    [SerializeField] GameObject textPlayBlob;
    [SerializeField] GameObject btnbai;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ActivateBlob()
    {
        textOrbitar.SetActive(false);
        fishObjec.SetActive(true);
        textPlayBlob.SetActive(true);
        btnBeforeBob.SetActive(false);
        btnbai.SetActive(true);
    }
}
