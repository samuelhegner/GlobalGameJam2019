using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
    LaserManager LM;
    public bool beingHit;
    
    // Start is called before the first frame update
    void Start()
    {
        LM = GameObject.Find("Manager").GetComponent<LaserManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterHit ()
    {
        beingHit = true;
    }

    public void exitHit()
    {
        beingHit = true;
    }
}
