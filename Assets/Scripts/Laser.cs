using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LayerMask layerMask;
    LineRenderer LR;
    //public LineRenderer LR2, LR3;
    Transform holder;
    public List<GameObject> objects = new List<GameObject>();
    public GameObject currentObject;


    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        holder = GameObject.Find("Holder").transform;
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
               /* LR2.SetPosition(0, hit.transform.position);
                LR3.SetPosition(0, hit.transform.position);
                LR2.SetPosition(1, GameObject.Find(hit.transform.name.ToString() + " 1").transform.position);
                LR3.SetPosition(1, GameObject.Find(hit.transform.name.ToString() + " 2").transform.position);
                RaycastHit hit2;*/
                hit.transform.GetComponent<LaserHit>().HitByLaser();
                currentObject = hit.transform.gameObject;
            }
            else
            {
                if (currentObject != null)
                    StartCoroutine(stopSplitter());
            }
           
        }
        else
        {
           // Debug.DrawLine(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            //Debug.Log("Did not Hit");
        }
    }

    IEnumerator stopSplitter()
    {
        currentObject.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject = null;
    }
}
