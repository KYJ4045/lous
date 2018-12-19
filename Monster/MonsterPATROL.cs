using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterPATROL : MonsterFSMStat
{
    Vector3 destination;

    public override void BeginState()
    {
        base.BeginState();
        if (null != _monstermanager)
            //_monstermanager.Anim.CrossFade("SL_Walk");

        destination = new Vector3(Random.Range(-10, 0), 0, Random.Range(-10, 10));
    }
    public override void EndState()
    {
        base.EndState();
    }

   private  void Update ()
    {
		if(Vector3.Distance(destination, transform.position)<0.1f)
        {
            _monstermanager.SetState(MonsterState.IDLE);
            return;
        }
        if(Vector3.Distance(_monstermanager.PlayerTransform.position,transform.position)<_monstermanager.Stat.AttackRange)
        {
            _monstermanager.SetState(MonsterState.ATTACK);
            return;
        }

        _monstermanager.CC.CKMove(destination, _monstermanager.Stat);
	}
}
