using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool moving = false;
    private GameObject spear;
    private bool walking = false;
    private bool idle = true;
    public Animator playerAnimator;
    private Vector3 throwDirection;
    private Vector3 ogPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spear = GameObject.Find("Spear");
        ogPos = GameObject.Find("Spear").transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 0.2f;
            GetComponent<SpriteRenderer>().flipX = false;
            GameObject.Find("Spear").GetComponent<SpriteRenderer>().flipX = false;
            playerAnimator.SetBool("Walking", true);
            moving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 0.2f;
            GetComponent<SpriteRenderer>().flipX = true;
            GameObject.Find("Spear").GetComponent<SpriteRenderer>().flipX = true;
            playerAnimator.SetBool("Walking", true);
        }
        else
        {
            playerAnimator.SetBool("Idle", true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(transform.up * 900f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject.Find("Spear").transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject.Find("Spear").transform.position = new Vector3(GameObject.Find("Spear").transform.position.x, GameObject.Find("Spear").transform.position.y, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject.Find("Spear").transform.position = transform.position + ogPos;
        }
    }
}
