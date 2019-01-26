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
    GameObject currentObject;
    public GameObject sphere;
    bool checkHit1;


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

            if (hit.transform.name == "Sphere")
            {
                hit.transform.GetComponent<SphereDestroy>().resetPosition();
            }
        }

    }

    IEnumerator stopSplitter()
    {
        currentObject.GetComponent<LaserHit>().stopLaser();
        yield return new WaitForSeconds(Time.deltaTime);
        currentObject = null;
        yield return new WaitForSeconds(Time.deltaTime);
        checkHit1 = false;
    }
}
