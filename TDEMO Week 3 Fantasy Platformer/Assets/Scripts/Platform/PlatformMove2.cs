using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove2 : MonoBehaviour
{
    [SerializeField] private int UpValue = 0;
    [SerializeField] private int DownValue;  
    [SerializeField] private int Distance = 300;
    private float speed = 0.025f;


    void Awake()
    {
        DownValue = Distance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    //MOVING RIGHT
        if (UpValue < Distance)
        {
            transform.position = transform.position + new Vector3(0,speed,0);
            UpValue++; 
      
        if (UpValue >= Distance)
        {
            DownValue = 0;
        }
        }
        

        //MOVING LEFT
         if(DownValue < Distance)
        {
            transform.position = transform.position - new Vector3(0,speed,0);
            DownValue++;

        if (DownValue >= Distance)
        {
            UpValue = 0;
        }

        }


    }
}
