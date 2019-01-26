using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask layerMask;
    LineRenderer LR;
    public LineRenderer LR2, LR3;


    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        LR.SetPosition(0, transform.position);


        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.right, out hit, Mathf.Infinity, layerMask))
        {
           // Debug.DrawLine(transform.position, Vector3.right * hit.distance, Color.yellow);
           // Debug.Log(hit.transform.name);
            LR.SetPosition(1, hit.point);
           // Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "yes")
            {
                //LR2.SetPosition(0, hit.transform.position);
                //LR3.SetPosition(0, hit.transform.position);
                // LR2.SetPosition(1, hit.transform.position);
                // LR3.SetPosition(1, hit.transform.position);
                hit.transform.GetComponent<LaserHit>().HitByLaser();
            }
            else
            {

            }
        }
        else
        {
           // Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            //Debug.Log("Did not Hit");
        }
    }
}
