using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    //public  static Vector3 startPos;
    
    public static Vector3 targetPos;
    public static bool enableParticleSystem = false;
    public float speed = 10f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enableParticleSystem)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            print("working");

            if (transform.position == targetPos)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
