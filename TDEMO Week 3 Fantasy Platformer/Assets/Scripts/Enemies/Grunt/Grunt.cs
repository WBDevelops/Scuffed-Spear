using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Grunt: MonoBehaviour
{

    public float walkspeed;

    public Transform groundCheckPos;
    public GameObject Self;

    public Rigidbody2D rb;

    public int Health;
    public float Iframes;
    public float IframesTotal;
    public bool Invinceble;

    public AudioController audioController;
    public AudioSource deathAudio;

    private List<TilemapCollider2D> StageColliders = new List<TilemapCollider2D>();

    void Start()
    {
        Invinceble = false;
        GameObject[] TileMapGO = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject Go in TileMapGO)
        {
            TilemapCollider2D SC = Go.GetComponent<TilemapCollider2D>();
            StageColliders.Add(SC);
        }
    }

    void FixedUpdate()
    {
        int count = 0;
        foreach (TilemapCollider2D StageCollider in StageColliders.ToArray())
        {
            if (!StageCollider.OverlapPoint(new Vector3(groundCheckPos.transform.position.x, groundCheckPos.transform.position.y, 0)))
            {
                count++;
            }

        }
        if (count >= StageColliders.Count)
        {
            Flip();
        }
        else
        {
            rb.velocity = new Vector2(walkspeed, 0f);
        }
        if (Invinceble)
        {
            Iframes = Iframes - Time.deltaTime;
        }
        if ( Iframes <= 0 )
        {
            Invinceble = false;
            Iframes = 0;
        }


    }

    public void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed = -walkspeed;
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
            }

            if (Health <= 0)
            {
                Destroy(Self);
            }
        }
    }

}
