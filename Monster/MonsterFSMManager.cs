using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState
{
    IDLE = 0,
    PATROL,
    CHASE,
    ATTACK,
    DEAD
}

[RequireComponent(typeof(MonsterStat))]
[ExecuteInEditMode]
public class MonsterFSMManager : MonoBehaviour
{
    private bool _isinit = false;
    public MonsterState startState = MonsterState.IDLE;
    private Dictionary<MonsterState, MonsterFSMStat> _states = new Dictionary<MonsterState, MonsterFSMStat>();

    [SerializeField]
    private MonsterState _currentState;
    public MonsterState CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private CharacterController _playercc;
    public CharacterController PlayerCC { get { return _playercc; } }

    private Transform _playerTransform;
    public Transform PlayerTransform { get { return _playerTransform; } }

    private MonsterStat _stat;
    public MonsterStat Stat { get { return _stat; } }

    private Animation _anim;
    public Animation Anim { get { return _anim; } }

    private Camera _sight;
    public Camera Sight { get { return _sight; } }

    [SerializeField]
    private float _monsterHP;
    public float MonsterHP { get { return _monsterHP; } }

    public int sightAspect = 3;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _stat = GetComponent<MonsterStat>();
        _anim = GetComponentInChildren<Animation>();
        _sight = GetComponentInChildren<Camera>();
        _sight.aspect = sightAspect;

        _playercc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        _playerTransform = _playercc.transform;

        MonsterState[] stateValues = (MonsterState[])System.Enum.GetValues(typeof(MonsterState));
        foreach (MonsterState s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Monster" + s.ToString());
            MonsterFSMStat state = (MonsterFSMStat)GetComponent(FSMType);
            if (null == state)
            {
                state = (MonsterFSMStat)gameObject.AddComponent(FSMType);
            }

            _states.Add(s, state);
            state.enabled = false;
        }
    }
    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public void SetState(MonsterState newState)
    {
        if (_isinit)
        {
            _states[_currentState].enabled = false;
            _states[_currentState].EndState();
        }
        _currentState = newState;
        _states[_currentState].BeginState();
        _states[_currentState].enabled = true;
    }

    private void OnDrawGizmos()
    {
        if (_sight != null)
        {
            Gizmos.color = Color.red;
            Matrix4x4 temp = Gizmos.matrix;

            Gizmos.matrix = Matrix4x4.TRS(_sight.transform.position, _sight.transform.rotation, Vector3.one);

            Gizmos.DrawFrustum(Vector3.zero, _sight.fieldOfView, _sight.farClipPlane, _sight.nearClipPlane, _sight.aspect);

            Gizmos.matrix = temp;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Bullet")
        {
            if (_monsterHP >= 0)
            {
                Debug.Log("Bullet Hit");
                _monsterHP -= BulletCtrl.Damage;
            }
            else
                SetState(MonsterState.DEAD);
        }
    }
}
