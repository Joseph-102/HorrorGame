using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;


public class BossPatrol : BossStateAbstract
{
    private float _range = 20;
    public int deceleratingSpeed = 5;
    public int acceleratingSpeed = 2;
    // Start is called before the first frame update
    public override void EnterState(BossStateManager Agent)
    {
        Debug.Log("Entered the Patrol State");
    }

    public override void ExitState(BossStateManager Agent)
    {
        
    }

    public override void UpdateState(BossStateManager Agent)
    {
        if(Agent.agent.stoppingDistance + 2 >= Agent.agent.remainingDistance)
        {
            if (Agent.bossSpeed > 0)
                Agent.bossSpeed -= Time.deltaTime * deceleratingSpeed;
        }
        if (Agent.agent.stoppingDistance + 2 <= Agent.agent.remainingDistance)
        {
            if ((Agent.bossSpeed < 3.5f))
                Agent.bossSpeed += Time.deltaTime * acceleratingSpeed;
        }
        //Debug.Log("Here");
        if (Agent.agent.stoppingDistance >= Agent.agent.remainingDistance)
        {
            Vector3 point;
            if (RandomPoint(Agent.gameObject.transform.position, _range, out point))
            {
                //Debug.Log("Here");
                Agent.agent.destination = point;
            }
        }       
    }

    private bool RandomPoint(Vector3 centerPosition, float range, out Vector3 result)
    {
        Vector3 randomPoint = centerPosition + UnityEngine.Random.insideUnitSphere * range;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint,out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
