using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject PlayerObject;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(PlayerObject.transform.position, Self.transform.position) <= 0.5)
        {
            Destroy(Self);
        }
    }
}
