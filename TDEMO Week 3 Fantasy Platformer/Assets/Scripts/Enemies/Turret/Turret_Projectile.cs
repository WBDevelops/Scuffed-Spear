using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Turret_Projectile : MonoBehaviour
{
    private List<TilemapCollider2D> StageColliders = new List<TilemapCollider2D>();
    public GameObject Self;
    public float ShotSpeed = 1f;
    void Start()
    {
        GameObject[] TileMapGO = GameObject.FindGameObjectsWithTag("Ground");
        foreach(GameObject Go in TileMapGO)
        {
            TilemapCollider2D SC = Go.GetComponent<TilemapCollider2D>();
            StageColliders.Add(SC);
        }
        StartCoroutine(AutoDelete());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (TilemapCollider2D StageCollider in StageColliders.ToArray())
        {
            if (StageCollider.OverlapPoint(new Vector3(transform.position.x, transform.position.y, 0)))
            {
                Destroy(Self);
            }
            
        }
        Self.transform.position = Self.transform.position + Self.transform.right * -ShotSpeed * Time.deltaTime;
    }

    IEnumerator AutoDelete()
    {
        yield return new WaitForSeconds(10);
        Destroy(Self);
    }

}
