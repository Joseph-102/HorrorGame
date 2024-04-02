using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossSight : MonoBehaviour
{
    public LayerMask _targetMask;
    public LayerMask _obstacleMask;
    private bool _seenPlayer;
    public int _range;
    public int angle;
    private bool prev;
    private Vector3 _playerPosition = Vector3.zero;
    private Vector3 _directionToTarget;
    public BossStateManager bossStateManager;
    private BossChase bossChase = new BossChase();
    private BossPatrol bossPatrol = new BossPatrol();
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Sight function called");
        StartCoroutine(BossSightFunction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator BossSightFunction()
    {
        //Debug.Log("Sight check 1");
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _seenPlayer = FieldOfViewCheck();
            if (_seenPlayer != prev && _seenPlayer == true)
            {
                bossStateManager.currentState = bossChase;
                bossChase.EnterState(bossStateManager);
                prev = _seenPlayer;
            }
            else if(_seenPlayer != prev && _seenPlayer == false)
            {
                bossStateManager.currentState.ExitState(bossStateManager);
                bossStateManager.currentState = bossPatrol;
                bossPatrol.EnterState(bossStateManager);
                prev = _seenPlayer;
            }
        }
    }

    private bool FieldOfViewCheck()
    {
        Collider[] collidedObjects = Physics.OverlapSphere(transform.position , _range, _targetMask);
        if(collidedObjects.Length > 0)
        {
            //Debug.Log("Saw the player");
            _playerPosition = collidedObjects[0].transform.position;
            bossStateManager.playerPos = _playerPosition;
            _directionToTarget = (_playerPosition - transform.position).normalized;
            if(Vector3.Angle(transform.forward,_directionToTarget) < angle / 2)
            {
                return true;
            }
        }

        return false;
    }
}
