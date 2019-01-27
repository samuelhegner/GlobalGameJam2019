using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    public Animator anim;
    TargetBlock TB, TB2;
    public int targetHits;
    public int targetsNeeded;
    AudioSource aud;
    bool doorOpened;
    public bool usingLaser;
    public Laser laser1;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();

        if (usingLaser)
        {
            laser1.stopLaser();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHits == targetsNeeded + 2)
        {
            anim.SetBool("doorOpen", true);
            if (!doorOpened)
            {
                aud.Play();
                doorOpened = true;
            }

        } else
        {
            anim.SetBool("doorOpen", false);
            aud.Stop();
            doorOpened = false;
        }

        if (targetHits >= targetsNeeded && usingLaser)
        {
            laser1.startLaser();
        }
        else
        {   
            if (usingLaser)
                laser1.stopLaser();
        }   
    }


    public void targetsHit()
    {
        anim.SetBool("doorOpen", true);
    }
}
