using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_HitCollision : MonoBehaviour
{

    public GameObject Self;
    private AudioController audioController;
    public AudioSource deathAudio;

    void Start()
    {
        GameObject audioControllerGo = GameObject.Find("AudioController");
        audioController = audioControllerGo.GetComponent<AudioController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.gameObject.tag == "PlayerAttack")
        {
            audioController.PlayNoise(deathAudio,0.5f);
            Destroy(Self);
        }  
    }

}
