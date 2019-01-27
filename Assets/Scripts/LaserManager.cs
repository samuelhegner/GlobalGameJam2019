using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{

    public Animator anim;
    public TargetBlock TB, TB2;
    public int targetHits;
    public int targetsNeeded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHits == targetsNeeded)
        {
            anim.SetBool("doorOpen", true);
        } else
        {
            anim.SetBool("doorOpen", false);
        }
    }


    public void targetsHit()
    {
        anim.SetBool("doorOpen", true);
    }
}
