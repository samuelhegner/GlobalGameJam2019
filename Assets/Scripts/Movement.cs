using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    NavMeshAgent agent;
    NavMeshObstacle obstacle;

    public GameObject part;

    private Renderer rend;

    public Color inactiveColour;
    public Color activeColour;
    
    
    


    Camera cam;

    public bool activePlayer;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        
        agent = GetComponent<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        cam = Camera.main;
        part = GameObject.Find("Particle Spawner");
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
            //ParticleMovement.startPos = agent.transform.position;
            //click to move
            if (Input.GetMouseButtonDown(0))
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
                            
                            rend.material.color = Color.Lerp(rend.material.color, activeColour, Time.deltaTime);
                            
                            
                            part.SetActive(false);
                            part.transform.position = transform.position;
                            
                            ParticleMovement.enableParticleSystem = true;
                            part.SetActive(true);
                            
                            ParticleMovement.targetPos = potentialPlayer.transform.position;
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
            rend.material.color = Color.Lerp(rend.material.color, inactiveColour, Time.deltaTime);
        }


    }
}
