using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum enemyState
{
    wandering,
    chasingPlayer,
    closeAttacking,
    longAttacking,
}

public class FSM : MonoBehaviour
{
    [SerializeField]
    private LayerMask ground;
    [SerializeField]
    private LayerMask player;
    private float closeAttackRange;
    private float longAttackRange;
    private float chasingRange;
    private float stoppingDistance=2f;
    private float enemySpeed = 0.5f;
    private Vector3 destination;
    private Quaternion desiredRotation;
    private Vector3 direction;
    [SerializeField]
    private GameObject target;
    private enemyState currentState;



    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        switch (currentState)
        {
            case enemyState.wandering:
            {
                    if (needsDestination())
                    {
                        GetDestination();
                    }

                    transform.rotation = desiredRotation;
                    transform.Translate(Vector3.forward * Time.deltaTime * enemySpeed) ;
                    if(!(Physics.Raycast(destination, -transform.up, 0.5f, ground)))
                    {
                        Debug.Log(destination);
                        Debug.Log("Not a ground!");
                        GetDestination();
                    }

                    if(Physics.CheckSphere(transform.position, chasingRange, player))
                    {
                        currentState = enemyState.chasingPlayer;
                    }
                    break;


            }

            case enemyState.chasingPlayer:
            {
                    if(target == null)
                    {
                        currentState = enemyState.wandering;
                        return;
                    }
                    break;
            }

            case enemyState.closeAttacking:
            {
                    break;
            }

            case enemyState.longAttacking:
            {
                    break;
            }
        }
    }

    private bool needsDestination()
    {
        if(destination == Vector3.zero)
        {
            return true;
        }

        var distance = Vector3.Distance(transform.position, destination);
        if(distance<= stoppingDistance)
        {
            return true;
        }

        return false;
    }

    private void GetDestination()
    {
        Vector3 testPosition = (transform.position + (transform.forward)*4f) + new Vector3(Random.Range(-4.5f,4.5f), 0, Random.Range(-4.5f, 4.5f));

        destination = new Vector3(testPosition.x, 6f, testPosition.z);
        direction = Vector3.Normalize(destination - transform.position);
        direction = new Vector3(direction.x, 0f, direction.z);
        desiredRotation = Quaternion.LookRotation(direction);
    }
}
 