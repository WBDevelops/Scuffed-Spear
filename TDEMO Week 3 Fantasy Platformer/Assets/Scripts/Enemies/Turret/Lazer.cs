using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Lazer : MonoBehaviour
{
    private List<TilemapCollider2D> StageColliders = new List<TilemapCollider2D>();
    public GameObject Self;
    public float ShotSpeed = 0.1f;

    public GameObject Projectile;

    void Start()
    {
        Self.transform.position += Self.transform.right * -0.1f;
        GameObject[] TileMapGO = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject Go in TileMapGO)
        {
            TilemapCollider2D SC = Go.GetComponent<TilemapCollider2D>();
            StageColliders.Add(SC);
        }
        bool stop = false;
        foreach (TilemapCollider2D StageCollider in StageColliders.ToArray())
        {
            if (StageCollider.OverlapPoint(new Vector3(transform.position.x, transform.position.y, 0)))
            {
                Destroy(Self);
                stop = true;
            }
        }
        
        if (!stop)
        {
            Instantiate(Projectile, transform.position, transform.rotation);
        }
        StartCoroutine(AutoDelete());
    }

    IEnumerator AutoDelete()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(Self);
    }
}
