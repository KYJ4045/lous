using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Manager))]
public class FSM_State : MonoBehaviour
{
    protected FSM_Manager _manager;

    private void Awake()
    {
        _manager = GetComponent<FSM_Manager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }
}
