using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    public int enemySpeed = 10;
    bool isOnGround = true;
    bool isMoving = false;
    public Animator animator;
    private Vector3 playerPos;
    public int enemy_radius = 10;
    private AlienDeath AlienDeath;
    bool fireFinished = true;
    //Rigidbody rb;
    NavMeshAgent agent;
    // Start is called before the first frame update

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        AlienDeath = GetComponent<AlienDeath>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (AlienDeath.isDead)
        {
            agent.enabled = false;
        }

        else
        {
            agent.destination = playerTransform.position;
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        if((agent.destination - transform.position).magnitude < 4 && fireFinished)
        {
            Debug.Log("Close");
            fireFinished = false;
            animator.SetBool("isFiring", true);
            StartCoroutine(FireAnimation());
        }

        
    }

   
    IEnumerator FireAnimation()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(3.08f);
        animator.SetBool("isFiring", false);
        agent.isStopped = false;
        fireFinished = true;
    }
}
