using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDEAD : FSM_State
{
    public override void BeginState()
    {
        base.BeginState();
    }

    public override void EndState()
    {
        base.EndState();
    }

    private void Update()
    {
        Debug.Log("DEAD");
    }

}
