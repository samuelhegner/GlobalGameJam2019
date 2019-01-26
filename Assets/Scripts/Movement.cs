﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshObstacle obstacle;


    Camera cam;

    public bool activePlayer;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        cam = Camera.main;

        if (activePlayer)
        {
            agent.enabled = true;
            obstacle.enabled = false;
        }
        else {
            agent.enabled = false;
            obstacle.enabled = true;
        }
    }

    void Start()
    {
        agent.updateRotation = false;
        agent.acceleration = 100f;
    }

    void Update()
    {

        if (activePlayer)
        {
            agent.enabled = true;
            obstacle.enabled = false;
            //click to move
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {
                    if (hit.transform.tag == "Ground")
                    {
                        print("test" + hit.point);
                        agent.SetDestination(hit.point);
                        //Debug.DrawRay(ray.origin, ray.direction * 1000f, Color.red);
                    }
                }



            }

            //click to switch object
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 1000f))
                {

                    if (hit.transform.tag == "Player")
                    {
                        GameObject potentialPlayer = hit.transform.gameObject;
                        if (potentialPlayer.GetComponent<Movement>().activePlayer == false)
                        {
                            potentialPlayer.GetComponent<Movement>().activePlayer = true;
                            agent.SetDestination(transform.position);
                            activePlayer = false;
                        }
                    }
                }

            }
        }
        else
        {
            agent.enabled = false;
            obstacle.enabled = true;
        }


    }
}