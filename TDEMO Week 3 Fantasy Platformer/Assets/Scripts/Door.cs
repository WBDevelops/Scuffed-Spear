using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Self;
    public GameObject Key;
    public GameObject TextBox;
    public GameObject PlayerObject;


    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerObject.transform.position, Self.transform.position) <= 1.5)
        {
            if (Key == null)
            {
                Destroy(Self);
            }
            else
            {
                TextBox.SetActive(true);
                StartCoroutine(TextOff());
            }
        }
    }

    IEnumerator TextOff()
    {
        yield return new WaitForSeconds(2f);
        TextBox.SetActive(false);
    }
}
