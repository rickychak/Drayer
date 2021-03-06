using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ExecutionState
{
    NONE,
    ACTIVE,
    COMPLETED,
    TERMINATED,
};
public abstract class abstractFSMState :ScriptableObject
{

   public ExecutionState ExecutionState { get; protected set; }

    public virtual void OnEnabled()
    {
        ExecutionState = ExecutionState.NONE;
    }
    public virtual bool EnterState()
    {
        ExecutionState = ExecutionState.ACTIVE;
        return true;
    }

    public virtual bool ExitState()
    {
        ExecutionState = ExecutionState.COMPLETED;
        return true;
    }


    public abstract void UpdateState();
}
