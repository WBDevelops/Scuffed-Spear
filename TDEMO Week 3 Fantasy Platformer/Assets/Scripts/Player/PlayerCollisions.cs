using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    private float health = 1f;

    public AudioController audioController;
    public AudioSource deathAudio;
    public GameObject Self;

    public float Iframes;
    public float IframesTotal;

    public bool Invinceble;

    private void Start()
    {
        health += GameObject.Find("DontDestroyOnLoad").GetComponent<DontDestroyOnLoad>().difficulty;
    }

    void FixedUpdate()
    {
        if (Invinceble)
        {
            Iframes = Iframes - Time.deltaTime;
        }
        if (Iframes <= 0)
        {
            Invinceble = false;
            Iframes = 0;
        }

        GameObject.Find("Lives").GetComponent<Text>().text = "Lives: " + health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Enemy")
        {
            audioController.PlayNoise(deathAudio, 0.5f);
            if (!Invinceble)
            {
                health--;
                Iframes = IframesTotal;
                Invinceble = true;
            }

            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
