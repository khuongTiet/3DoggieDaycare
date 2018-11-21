using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour {
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    Animator anim;

    private Quaternion lookRotation;
    private Vector3 playerDirection;

    public float RotationSpeed = 5;
    public float DetectRange;
    public bool FollowingPlayer = false;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.Warp(transform.position);
    }


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
    }


    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= DetectRange) {
            FollowingPlayer = true;
            if (!anim.GetBool("IsWalking"))
            {
                anim.SetBool("IsWalking", true);
            }
        } else {
            FollowingPlayer = false;
            if (anim.GetBool("IsWalking"))
            {
                anim.SetBool("IsWalking", false);
            }
        }

        if (FollowingPlayer) {
            nav.SetDestination(player.position);

            playerDirection = (player.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(playerDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);


        } 
    }
}
