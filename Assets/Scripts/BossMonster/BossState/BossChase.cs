using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChase : BossStateAbstract
{
    [SerializeField] BossChase chase;
    public Transform playerPos;
    private bool chaseMode;
    public int deceleratingSpeed = 5;
    public int acceleratingSpeed = 2;


    // Start is called before the first frame update
    public override void EnterState(BossStateManager Agent)
    {
        Debug.Log("Entered the Chase State");
        chaseMode = true;
        Agent.StartCoroutine(GoToPlayer(Agent));
        
    }

    public override void ExitState(BossStateManager Agent)
    {
        chaseMode = false;
    }

    public override void UpdateState(BossStateManager Agent)
    {
        if (Agent.agent.stoppingDistance + 2 >= Agent.agent.remainingDistance)
        {
            if (Agent.bossSpeed > 0)
                Agent.bossSpeed -= Time.deltaTime * deceleratingSpeed;
        }
        if (Agent.agent.stoppingDistance + 2 <= Agent.agent.remainingDistance)
        {
            if ((Agent.bossSpeed < 3.5f))
                Agent.bossSpeed += Time.deltaTime * acceleratingSpeed;
        }
        if ((Agent.agent.remainingDistance < 0.5))
        {
            Agent.animator.SetBool("isAttacking", true);
            Agent.StartCoroutine(StopAttacking(Agent));
        }
        Agent.bossSpeed = Mathf.Clamp(Agent.bossSpeed, 0f, 3.6f);
    }

    private IEnumerator GoToPlayer(BossStateManager Agent)
    {
        while (chaseMode)
        {
            Debug.Log("Go To player");
            yield return new WaitForSeconds(0.5f);
            Agent.agent.destination = Agent.playerPos;
        }
    }

    private IEnumerator StopAttacking(BossStateManager Agent)
    {
        yield return new WaitForSeconds(2.18f);
        Agent.animator.SetBool("isAttacking", false);
    }
}
