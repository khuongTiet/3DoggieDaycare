using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour {
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;

    public float DetectRange;
    public bool FollowingPlayer = false;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        if (Vector3.Distance(player.position, transform.position) <= DetectRange) {
            FollowingPlayer = true;
        } else {
            FollowingPlayer = false;
        }

        if (FollowingPlayer) {
            nav.SetDestination(player.position);
        }
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
