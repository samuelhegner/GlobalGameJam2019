﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask layerMask;
    public LineRenderer LR, LR2;
    public Transform holder;
    public GameObject currentObject, currentObject2;
    bool checkHit1, checkHit2;
    public bool targetHit1, targetHit2;
    public GameObject sphere;
    public LaserManager LM;
    AudioSource aud;
    
    public GameObject sparks1;
    public GameObject sparks2;


    void Start()
    {
        LR.SetPosition(0, holder.position);
        LR2.SetPosition(0, holder.position);
        LR.SetPosition(1, holder.position);
        LR2.SetPosition(1, holder.position);

        holder = GameObject.Find("Holder").transform;

        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetHit1 && targetHit2)
        {
            LM.targetsHit();
        }
    }


    public void HitByLaser ()
    {
        LR.SetPosition(0, transform.position);
        LR2.SetPosition(0, transform.position);

       // if (!aud.isPlaying)
       //     aud.Play();

       // Debug.Log(GameObject.Find("DividerCube 2").transform.name);
        // Debug.DrawLine(transform.position, (GameObject.Find(transform.name.ToString() + " 1").transform.position - transform.position).normalized * 100, Color.yellow);

        

        RaycastHit hit, hit2;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z), (transform.forward + transform.right).normalized, out hit, 100, layerMask))
        {
            sparks1.transform.position = hit.point;
            sparks1.transform.rotation = Quaternion.LookRotation(-(transform.forward + transform.right).normalized); 
            if (hit.transform.name == "Sphere")
            {
                hit.transform.GetComponent<SphereDestroy>().resetPosition();
            }

            

            if (hit.transform.name == "TargetCube")
            {
                Debug.Log(hit.transform.name);
                if (!targetHit1)
                {
                    LM.targetHits += 1;
                    targetHit1 = true;
                }
               // hit.transform.GetComponent<TargetBlock>().enterHit();
            }
            else
            {
                
                if (targetHit1)
                {
                    LM.targetHits -= 1;
                    targetHit1 = false;
                }
            }

            //Debug.Log(hit.transform.name);
            LR.SetPosition(1, hit.point);
            // Debug.Log("splitHit");
            if (hit.transform.name == "Pyramid")
            {
                hit.transform.GetComponent<LaserHit>().HitByLaser();
                if (!checkHit1)
                {
                    currentObject = hit.transform.gameObject;
                    checkHit1 = true;
                }
                if (currentObject != hit.transform.gameObject)
                {
                    StartCoroutine(stopSplitter());
                }
            }
            else
            {
                if (currentObject != null)
                    StartCoroutine(stopSplitter());
            }
        }

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + .25f, transform.position.z), (-transform.forward + transform.right).normalized, out hit2, 100, layerMask))
        {
            // Debug.DrawLine(transform.position, (GameObject.Find(transform.name.ToString() + " 1").transform.position - transform.position).normalized * hit.distance, Color.yellow);
            //  Debug.Log(hit.transform.name);
            sparks2.transform.position = hit2.point;
            sparks2.transform.rotation = Quaternion.LookRotation(-(-transform.forward + transform.right).normalized); 
            if (hit2.transform.name == "Sphere")
            {
                hit2.transform.GetComponent<SphereDestroy>().resetPosition();
            }

            if (hit2.transform.name == "TargetCube")
            {
                
                if (!targetHit2)
                {
                    LM.targetHits += 1;
                    targetHit2 = true;
                }
               // hit2.transform.GetComponent<TargetBlock>().enterHit();
            }
            else
            {
                if (targetHit2)
                {
                    LM.targetHits -= 1;
                    targetHit2 = false;
                }
            }

            LR2.SetPosition(1, hit2.point);
            if (hit2.transform.name == "Pyramid")
            {
                hit2.transform.GetComponent<LaserHit>().HitByLaser();
               // if (hit2.transform.tag == "yes")
                    if (!checkHit2)
                    {
                        currentObject2 = hit2.transform.gameObject;
                        checkHit2 = true;
                    }
                if (currentObject2 != hit2.transform.gameObject) {
                    StartCoroutine(stopSplitter2());
                }
            } 
            else
            {
               
                if (currentObject2 != null) 
                    StartCoroutine(stopSplitter2());
            }
        }
        
    }

    public void stopLaser ()
    {
        LR.SetPosition(0, holder.position);
        LR2.SetPosition(0, holder.position);
        LR.SetPosition(1, holder.position);
        LR2.SetPosition(1, holder.position);
        sparks1.transform.position = holder.position;
        sparks2.transform.position = holder.position;
        if (currentObject != null)
            StartCoroutine(stopSplitter());
        if (currentObject2 != null)
            StartCoroutine(stopSplitter2());
        if (targetHit1)
        {
            LM.targetHits -= 1;
            targetHit1 = false;
        }
        if (targetHit2)
        {
            LM.targetHits -= 1;
            targetHit2 = false;
        }
       // aud.Stop();
    }


    IEnumerator stopSplitter()
    {
        currentObject.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject = null;
        yield return new WaitForSeconds(Time.deltaTime);
        checkHit1 = false;
    }

    IEnumerator stopSplitter2 ()
    {
        currentObject2.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject2 = null;
        yield return new WaitForSeconds(Time.deltaTime);
        checkHit2 = false;
    }
}
