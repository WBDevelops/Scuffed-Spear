using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    public float difficulty;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            difficulty = GameObject.Find("Play Button").GetComponent<MenuManager>().difficulty;

            volume = GameObject.Find("Play Button").GetComponent<MenuManager>().volume;
        }
    }
}
