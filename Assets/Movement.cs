using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;

    Camera cam;

    bool activePlayer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    void Start()
    {
        agent.updateRotation = false;
    }

    void Update()
    {
        //click to move
        if (Input.GetMouseButton(1)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                
                if (hit.transform.tag == "Ground")
                {
                    print("test" + hit.point);
                    agent.SetDestination(hit.point);
                    Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red);
                }
            }

        }

    }

    
}
