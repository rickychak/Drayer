using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    NavMeshAgent agent;

    // this is just for syncing the monster speed and animation walking speed -R
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetFloat("animationMultiplier", agent.speed * 0.4f);
    }

    
}
