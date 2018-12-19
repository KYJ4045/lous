using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player_State //캐릭터 상태
{
    IDLE = 0,
    RUN,
    ATTACK,
    DEAD
}

[RequireComponent(typeof(Player_State))]
[ExecuteInEditMode]
public class FSM_Manager : MonoBehaviour
{
    public float speed = 10.0f; //캐릭터 움직임 속도

    private Rigidbody _rigdbody;
    public Rigidbody RigdBody { get { return _rigdbody; } }

    private bool _isinit = false;
    public Player_State startState = Player_State.IDLE;
    private Dictionary<Player_State, FSM_State> _state
        = new Dictionary<Player_State, FSM_State>();

    [SerializeField]
    private Player_State _currentState; //기본적인 캐릭터 상태
    public Player_State CurrentState
    {
        get
        {
            return _currentState;
        }
    }

    public FSM_State CurrentStateComponent
    {
        get { return _state[_currentState]; }
    }


    private CharacterController _cc;
    public CharacterController CC { get { return _cc; } }

    private Camera _sight;
    public Camera Sight { get { return _sight; } }

    public int sightAspect = 3;

    public CharacterController testTarget;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _rigdbody = GetComponent<Rigidbody>();
        _sight = GetComponentInChildren<Camera>();
        _sight.aspect = sightAspect;

        Player_State[] stateValues = (Player_State[])System.Enum.GetValues(typeof(Player_State));
        foreach (Player_State s in stateValues)
        {
            System.Type FSMType = System.Type.GetType("Player" + s.ToString());
            FSM_State state = (FSM_State)GetComponent(FSMType);
            if (null == state)
            {
                state = (FSM_State)gameObject.AddComponent(FSMType);
            }

            _state.Add(s, state);
            state.enabled = false;
        }
    }

    private void Start()
    {
        SetState(startState);
        _isinit = true;
    }

    public void SetState(Player_State newState)
    {
        if (_isinit)
        {
            _state[_currentState].BeginState();
            _state[_currentState].enabled = true;
        }
        _currentState = newState;
        _state[_currentState].BeginState();
        _state[_currentState].enabled = true;
       // _anim.SetInteger("CurrentState", (int)_currentState);
    }

    private void Update()
    {
        MoveObject();
    }

    public void MoveObject()
    {
        //Move
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed);
        }
    }
    private void OnDrawGizmos()
    {
        if (_sight != null)
        {
            Gizmos.color = Color.blue;
            Matrix4x4 temp = Gizmos.matrix;

            Gizmos.matrix = Matrix4x4.TRS(_sight.transform.position, _sight.transform.rotation, Vector3.one);

            Gizmos.DrawFrustum(Vector3.zero, _sight.fieldOfView, _sight.farClipPlane, _sight.nearClipPlane, _sight.aspect);

            Gizmos.matrix = temp;
        }
    }

}
