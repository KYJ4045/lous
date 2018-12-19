using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRUN : FSM_State
{
    public override void BeginState()
    {
        base.BeginState();
       // _manager.Anim.CrossFade("KK_Run");
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {

    }



}
