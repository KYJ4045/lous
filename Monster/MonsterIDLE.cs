using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIDLE : MonsterFSMStat
{
    public float idleTime = 5.0f;
    private float time = 0.0f;

    public override void BeginState()
    {
        base.BeginState();
        if (null != _monstermanager)
           // _monstermanager.Anim.CrossFade("SL_Idle");

        time = 0.0f;
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
       if(GameLib.DetectCharacter(_monstermanager.Sight, _monstermanager.PlayerCC))
        {
            _monstermanager.SetState(MonsterState.CHASE);
            return;
        }

        Debug.Log("MonsterIDLE");
        time += Time.deltaTime;
        if(time>idleTime)
        {
            _monstermanager.SetState(MonsterState.PATROL);
        }    
    }
}
