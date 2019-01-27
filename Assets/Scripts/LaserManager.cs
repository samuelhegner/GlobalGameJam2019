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

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHits == targetsNeeded)
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
    }


    public void targetsHit()
    {
        anim.SetBool("doorOpen", true);
    }
}
