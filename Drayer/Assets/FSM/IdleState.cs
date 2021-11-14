using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "IdleState", menuName ="Unity-FSM/States/Idle", order = 1)]
public class IdleState: abstractFSMState
{
    public override void UpdateState()
    {
        Debug.Log("Updating Idle State");
    }

    public override bool EnterState()
    {
        base.EnterState();
        Debug.Log("Enter Idle State");
        return true;
    }

    public override bool ExitState()
    {
        base.ExitState();
        Debug.Log("Exit Idle State");
        return true;
    }
}
