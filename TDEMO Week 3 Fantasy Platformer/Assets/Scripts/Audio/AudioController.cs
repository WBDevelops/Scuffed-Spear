using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private DontDestroyOnLoad VolumeSlider;
    private float volumeSetting;

    public AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
         Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject NoDestroyLoad = GameObject.Find("DontDestroyOnLoad"); 
        if(NoDestroyLoad != null)
        {
            VolumeSlider = NoDestroyLoad.GetComponent<DontDestroyOnLoad>();
            volumeSetting = VolumeSlider.volume;
            Music.volume = VolumeSlider.volume;
        }
        else
        {
            volumeSetting = 1f;
        }

        if (!Music.isPlaying)
        {
            Music.Play();
        }
    }

    public void PlayNoise(AudioSource Noise)
    {

        Noise.volume = volumeSetting;
        Noise.Play();
    }
    public void PlayNoise(AudioSource Noise, float modifier)
    {
        Noise.volume = volumeSetting * modifier;
        Noise.Play();
    }
}
