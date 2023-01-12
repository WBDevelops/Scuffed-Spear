using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Turret : MonoBehaviour
{
    //Detection
    public TilemapCollider2D AggroArea;

    //GameObjects
    public GameObject target;
    public GameObject Self;
    public GameObject FirePoint;
    public GameObject Projectile;

    //animation
    public Animator animator;

    //Audio
    public AudioSource audioSource;
    public AudioController audioController;

    //Firing
    public float FireRate = 3f;
    public float NextShot;

    //Health
    public int Health;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        GameObject TileMap = GameObject.Find("AggroAreaTileMap");
        AggroArea = TileMap.GetComponent<TilemapCollider2D>();
        AnimationClip[] ClipInfo = animator.runtimeAnimatorController.animationClips;
        FireRate = (ClipInfo[0].length * 4f - 0.03f);
        NextShot = FireRate;
        Debug.Log("name: " + ClipInfo[0].name + " time:" + (ClipInfo[0].length * 4f - 0.01f));
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (AggroArea.OverlapPoint(new Vector3(target.transform.position.x, target.transform.position.y, 0)))
            {
                var dir = target.transform.position - Self.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Self.transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
                animator.SetBool("TargetAcquired", true);
                if (NextShot <= 0)
                {
                    NextShot = FireRate;
                    Instantiate(Projectile, FirePoint.transform.position, transform.rotation);
                    audioController.PlayNoise(audioSource);
                }
                else
                {
                    NextShot = NextShot - Time.deltaTime;
                }
            }
            else
            {
                animator.SetBool("TargetAcquired", false);
                Self.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            }
        }

    }
}
