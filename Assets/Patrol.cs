using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] waypoints = new GameObject[2];

    int current;

    public float speed;

    void Start()
    {
        current = 0;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, waypoints[current].transform.position) < 1f) {
            if (current == 0)
            {
                current = 1;
            }
            else {
                current = 0;
            }
        }
    }
}
