using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(FiniteStateMachine))]
public class NPC : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    FiniteStateMachine _finiteStateMachine;

    // Start is called before the first frame update
    public void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _finiteStateMachine = this.GetComponent<FiniteStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
