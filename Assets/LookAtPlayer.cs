using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public bool test;

    public GameObject testLookAt;
    public GameObject[] playerObjects;


    // Start is called before the first frame update
    void Start()
    {
        playerObjects = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject player in playerObjects)
        {
            if(player.GetComponent<Movement>().activePlayer == true)
            {
                testLookAt = player;
            }
        }

        if(test)
        transform.LookAt(testLookAt.transform.position);
    }
}
