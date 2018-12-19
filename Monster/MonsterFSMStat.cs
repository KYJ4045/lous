using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MonsterFSMManager))]
public class MonsterFSMStat : MonoBehaviour
{
    protected MonsterFSMManager _monstermanager;

    private void Awake()
    {
        _monstermanager = GetComponent<MonsterFSMManager>();
    }

    public virtual void BeginState()
    {

    }

    public virtual void EndState()
    {

    }

}
