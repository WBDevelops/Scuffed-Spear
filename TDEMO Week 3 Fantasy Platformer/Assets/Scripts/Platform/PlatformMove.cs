using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{

    [SerializeField] private int RightValue = 0;
    [SerializeField] private int LeftValue;  
    [SerializeField] private int Distance = 300;
    private float speed = 0.025f;


    void Awake()
    {
        LeftValue = Distance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    //MOVING RIGHT
        if (RightValue < Distance)
        {
            transform.position = new Vector2 (transform.position.x +speed , transform.position.y);
            RightValue++; 
      
        if (RightValue >= Distance)
        {
            LeftValue = 0;
        }
        }
        

        //MOVING LEFT
         if(LeftValue < Distance)
        {
            transform.position = new Vector2 (transform.position.x -speed , transform.position.y);
            LeftValue++;

        if (LeftValue >= Distance)
        {
            RightValue = 0;
        }

        }


    }
}
