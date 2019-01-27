using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    //public  static Vector3 startPos;
    
    public static Vector3 targetPos;
    public static bool enableParticleSystem = false;
    public float speed = 10f;

    public float minSpeed, maxSpeed;
    public float maxDistance;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float setSpeed = SetMoveSpeed(minSpeed, maxSpeed,targetPos, transform.position );
        if (enableParticleSystem)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, setSpeed* Time.deltaTime);
       

            if (transform.position == targetPos)
            {
                Invoke("DisableObject", 0.2f);
            }
        }

        print(setSpeed);


    }


    void DisableObject()
    {
        gameObject.SetActive(false);
    }
    
    public float SetMoveSpeed(float min, float max, Vector2 target, Vector2 current)
    {
        float dist = Vector2.Distance(target, current);            //Distance between target and pos of this object
        float targetSpeed;
        if (dist < maxDistance)                                    //if that distance is less than max distance
        {
            float speedPercent = dist / maxDistance;                //gets % of current dist relative to max distance
            targetSpeed = maxSpeed * speedPercent;                    // multiplies max speed by this % getting target speed
        }
        else
        {
            targetSpeed = max;
        }

        if (targetSpeed < min)
        {
            targetSpeed = min;
        }

        return targetSpeed;
    }
}
