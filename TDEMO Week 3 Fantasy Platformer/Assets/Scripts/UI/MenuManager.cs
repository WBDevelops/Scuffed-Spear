using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private string privateDifficulty;
    public float difficulty;
    public float volume = 0.5f;
    public GameObject Credits;
    public GameObject CreditsBackground;

    private void Start()
    {
        difficulty = 2f;
    }

    public void PlayButton()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void CreditsButton()
    {
        Credits.SetActive(!Credits.activeSelf);
        CreditsBackground.SetActive(!CreditsBackground.activeSelf);
    }

    public void Easy()
    {
        difficulty = 8f;
    }
    public void Medium()
    {
        difficulty = 6f;
    }
    public void Hard()
    {
        difficulty = 4f;
    }

    public void VolumeSlider(float setVolume)
    {
        volume = setVolume;
    }
}
