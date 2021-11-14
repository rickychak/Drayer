using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    [SerializeField]
    abstractFSMState _startingState;
    abstractFSMState _currentState;
    // Start is called before the first frame update
    public void Awake()
    {
        _currentState = null;
    }

    public void Start()
    {
        if(_startingState != null)
        {
            EnterState(_startingState);
        }
    }

    public void Update()
    {
        if(_currentState != null)
        {
            _currentState.UpdateState();
        }
    }
    #region
    public void EnterState(abstractFSMState nextState)
    {
        if(nextState == null)
        {
            return;
        }

        _currentState = nextState;
        _currentState.EnterState();
    }
    #endregion
}
