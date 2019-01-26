using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHit : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask layerMask;
    LineRenderer LR;
    public LineRenderer LR2;

    void Start()
    {
        LR = GetComponent<LineRenderer>();
        LR2 = GetComponentInChildren<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LR.SetPosition(0, transform.position);
        LR2.SetPosition(0, transform.position);
    }


    public void HitByLaser ()
    {
        
        Debug.Log("dividerHIt");

        RaycastHit hit, hit2;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(transform.position, Vector3.right * hit.distance, Color.yellow);
            Debug.Log(hit.transform.name);
            LR.SetPosition(1, hit.point);
          
        }

        if (Physics.Raycast(transform.position, Vector3.right, out hit2, Mathf.Infinity, layerMask))
        {
            Debug.DrawLine(transform.position, Vector3.back * hit.distance, Color.yellow);
            Debug.Log(hit.transform.name);
            LR2.SetPosition(1, hit.point);

        }
        
    }

}
