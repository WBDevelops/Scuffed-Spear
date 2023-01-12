using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteMoveScript : MonoBehaviour
{

    [SerializeField] private int RightValue = 0;
    [SerializeField] private int LeftValue = 145;
    [SerializeField] private int DropTimer = 25;
    [SerializeField] private int Distance = 150;
    [SerializeField] private Animator animation;

    public GameObject Boulder;
    public AudioSource Hehe;
    public Transform DropPoint;
    public GameObject Self;
    public int Health = 3;

    private float speed = 0.032f;

    public float Iframes;
    public float IframesTotal;

    public bool Invinceble;

    public AudioController audioController;
    public AudioSource deathAudio;

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

        //DROP BOULDER
        if (DropTimer < 250)
        {
            DropTimer++;
        }
        else
        {
            animation.Play("EliteBoudlerDrop");
            GameObject AudioGO = GameObject.Find("AudioController");
            AudioController audioController = AudioGO.GetComponent<AudioController>();
            audioController.PlayNoise(Hehe,0.7f);
            GameObject boulder = (GameObject)Instantiate(Boulder, DropPoint.position, Quaternion.identity);
            
            Destroy (boulder, 5f);
            DropTimer = 0;
        }

        if (Invinceble)
        {
            Iframes = Iframes - Time.deltaTime;
        }
        if (Iframes <= 0)
        {
            Invinceble = false;
            Iframes = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "PlayerAttack")
        {
            audioController.PlayNoise(deathAudio, 0.5f);
            if (!Invinceble)
            {
                Health--;
                Iframes = IframesTotal;
                Invinceble = true;
            }

            if (Health <= 0)
            {
                Destroy(Self);
            }
        }
    }
}
