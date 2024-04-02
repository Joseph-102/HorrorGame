using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossStateManager : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    private BossPatrol bossPatrol = new BossPatrol();
    public Vector3 playerPos;
    public BossStateAbstract currentState;
    public float bossSpeed = 0;
    
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentState = bossPatrol;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", bossSpeed);
        currentState.UpdateState(this);
    }
}
