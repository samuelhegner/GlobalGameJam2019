using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
    LaserManager LM;
    AudioSource aud; 
    
    // Start is called before the first frame update
    void Start()
    {
        LM = GameObject.Find("Manager").GetComponent<LaserManager>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterHit ()
    {
        //if (!aud.isPlaying)
        //    aud.Play();
    }
}
