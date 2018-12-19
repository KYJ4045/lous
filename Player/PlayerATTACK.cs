using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerATTACK : FSM_State
{
    public string bulletName = "Bullet";

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
        Debug.Log("ATTACK");
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {

    }

}
