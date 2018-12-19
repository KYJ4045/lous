using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterCHASE : MonsterFSMStat
{
    public Transform target;
    public Vector3 direction;
    public float chaseTime = 0.0f;
    public float StopChaseTime = 0.0f;

    public override void BeginState()
    {
        base.BeginState();
        //_monstermanager.Anim.CrossFade("SL_Run");
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        chaseTime += Time.deltaTime;
        target = GameObject.FindGameObjectWithTag("Player").transform; //플레이어 정보
        direction = target.position;
        MoveToTarget();

        if (!GameLib.DetectCharacter(_monstermanager.Sight, _monstermanager.PlayerCC))
        {
            _monstermanager.SetState(MonsterState.IDLE);
            return;
        }
        
    }

    public void MoveToTarget()
    {
        if (chaseTime <= 20.0f)
        {
            _monstermanager.CC.CKMove(direction, _monstermanager.Stat);
        }
        else if(StopChaseTime >=10.0f)
        {
            chaseTime = 0.0f;
            _monstermanager.SetState(MonsterState.CHASE);
            StopChaseTime = 0.0f;
        }
        else
        {
            _monstermanager.SetState(MonsterState.IDLE);
            StopChaseTime += Time.deltaTime;
        }
      
    }
}
