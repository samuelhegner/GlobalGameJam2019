﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDestroy : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition ()
    {
        transform.position = originalPos;
    }
}
