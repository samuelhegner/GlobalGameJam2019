using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask layerMask;
    public LineRenderer LR, LR2;
    public Transform holder;
    public GameObject currentObject, currentObject2;

    void Start()
    {
        LR.SetPosition(0, holder.position);
        LR2.SetPosition(0, holder.position);
        LR.SetPosition(1, holder.position);
        LR2.SetPosition(1, holder.position);

        holder = GameObject.Find("Holder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HitByLaser ()
    {
        LR.SetPosition(0, transform.position);
        LR2.SetPosition(0, transform.position);

        Debug.Log("dividerHit");
       // Debug.DrawLine(transform.position, (GameObject.Find(transform.name.ToString() + " 1").transform.position - transform.position).normalized * 100, Color.yellow);

        RaycastHit hit, hit2;
        if (Physics.Raycast(transform.position, (GameObject.Find("DividerCube 1").transform.position - transform.position).normalized, out hit, Mathf.Infinity, layerMask))
        {
           
            //Debug.Log(hit.transform.name);
            LR.SetPosition(1, hit.point);
            // Debug.Log("splitHit");
            if (hit.transform.tag == "yes")
            {
                hit.transform.GetComponent<LaserHit>().HitByLaser();
                currentObject = hit.transform.gameObject;
            }
            else
            {
                if (currentObject != null)
                    StartCoroutine(stopSplitter());
            }
        }

        if (Physics.Raycast(transform.position, (GameObject.Find("DividerCube 2").transform.position - transform.position).normalized, out hit2, Mathf.Infinity, layerMask))
        {
           // Debug.DrawLine(transform.position, (GameObject.Find(transform.name.ToString() + " 1").transform.position - transform.position).normalized * hit.distance, Color.yellow);
          //  Debug.Log(hit.transform.name);
            LR2.SetPosition(1, hit2.point);
            if (hit2.transform.tag == "yes")
            {
                hit2.transform.GetComponent<LaserHit>().HitByLaser();
                if (hit2.transform.tag == "yes")
                    currentObject2 = hit2.transform.gameObject;
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
        if (currentObject != null)
            StartCoroutine(stopSplitter());
        if (currentObject2 != null)
            StartCoroutine(stopSplitter2());
    }


    IEnumerator stopSplitter()
    {
        currentObject.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject = null;
    }

    IEnumerator stopSplitter2 ()
    {
        currentObject2.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject2 = null;
    }
}
