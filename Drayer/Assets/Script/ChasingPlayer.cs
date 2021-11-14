using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent agent;
    public LayerMask ground, player, enemy;
    Vector3 walkPoint;
    public GameObject arrow;
    bool walkPointSet;
    public float walkPointRange;           
    bool alreadyAttacked;
    bool playerInSightRange, playerInAttackRange;
    Animator animator;
    float currHealth;
    Collider thisCollider;
    bool isHit = false;
    public PlayerData playerData;
    public GolemData enemyData;
    public EnemyType enemyType;
    bool moneyAdded = false;
    int monsterIndex;

    public enum EnemyType
    {
        golem = 1,
        skeleton,
        dragon
    }

    private void Start()
    {
        for (int i =0; i<enemyData.monsterStat.Length; i++)
        {
            
            if (this.gameObject.name.Substring(0, enemyData.monsterStat[i].name.Length) == enemyData.monsterStat[i].name)
            {
                monsterIndex = i;
            }
        }
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        thisCollider = GetComponent<Collider>();
        //agent.speed = enemyData.enemySpeed;


    }
    IEnumerator DyingThreeSecondDelay()
    {
        yield return new WaitForSeconds(3f);

        this.gameObject.SetActive(false);

    }

    public void skeletonFSM()
    {
        if (currHealth > 0)
        {
            if (!playerInSightRange && !playerInAttackRange)
            {
                agent.isStopped = false;
                //agent.SetDestination(walkPoint);
                wandering();
            }
            else if (playerInSightRange && !playerInAttackRange)
            {
                // may change isStopped
                agent.isStopped = false;
                //skeleton Attack
                attacking();


            }
            else if (playerInAttackRange)
            {
                attacking();
            }
        }
        else
        {
            //Debug.Log("Passing");
            if (!moneyAdded)
            {
                if (this.gameObject.layer == 11)
                {
                    playerData.tempMoneyHolder += Random.Range(14, 16);
                }
                else
                {
                    playerData.tempMoneyHolder += Random.Range(14^2, 16^2);
                }
                moneyAdded = true;
            }
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            animator.SetTrigger("Dead");
            thisCollider.enabled = false;
            StartCoroutine(DyingThreeSecondDelay());
        }
    }
    public void golemFSM()
    {
        if (!isHit)
        {
            if (currHealth > 0)
            {
                if (!playerInSightRange && !playerInAttackRange)
                {
                    agent.isStopped = false;
                    wandering();
                }
                else if (playerInSightRange && !playerInAttackRange)
                {
                    agent.isStopped = false;
                    chasing();
                }
                else if (playerInAttackRange)
                {
                   
                    attacking();
                }
            }
            else
            {
                //Debug.Log("Passing");
                if (!moneyAdded)
                {
                    if(this.gameObject.layer == 11)
                    {
                        playerData.tempMoneyHolder += Random.Range(9,11);
                    }
                    else
                    {
                        playerData.tempMoneyHolder += Random.Range(9 ^ 2, 11 ^ 2);
                    }
                    
                    moneyAdded = true;
                }
                agent.velocity = Vector3.zero;
                agent.isStopped = true;
                animator.SetTrigger("Dead");
                thisCollider.enabled = false;
                StartCoroutine(DyingThreeSecondDelay());
            }
        }
        else
        {
            Debug.Log(animator.rootPosition);
            agent.nextPosition = animator.rootPosition;
        }
    }
    private void Update()
    {

        if (this.gameObject.layer == 11)
        {
            agent.speed = enemyData.monsterStat[monsterIndex].enemySpeed;
        }
        else
        {
            agent.speed = enemyData.monsterStat[monsterIndex].enemySpeed * 1.7f;
        }
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward);
        currHealth = GetComponent<DamageScript>().currHealth;
        Debug.DrawRay(transform.position + new Vector3(0, 1, 0), transform.forward * 2f, Color.red);
        playerInSightRange = Physics.CheckSphere(transform.position, enemyData.monsterStat[monsterIndex].sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, enemyData.monsterStat[monsterIndex].attackRange, player);
        if (enemyType == EnemyType.golem)
        {
            golemFSM();
        }
        else if (enemyType == EnemyType.skeleton)
        {
            skeletonFSM();
        }
        



    }


    
    private void wandering()
    {
        if (!walkPointSet)
        {
            searchingWhereToWalk();
        }
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);    
        }
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1.0f)
        {
            walkPointSet = false;
        }
    }

    private void searchingWhereToWalk()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 0.5f, ground))
        {
            walkPointSet = true;
        }
    }
    private void chasing()
    {
        agent.SetDestination(target.position);
    }

    IEnumerator skeletionAttackDelay()
    {
        alreadyAttacked = true;
        animator.SetBool("isAttacking", alreadyAttacked);
        yield return new WaitForSeconds(2f);
        GameObject firebullet = Instantiate(arrow, transform.position + new Vector3(0, 1.3f, 0) + this.transform.forward * 1.5f, transform.rotation);
        firebullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * 350.0f);


        // logic of hit
        // RaycastHit hit;
        //if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward, out hit, 2f, ~enemy))
        //{

        //    hit.transform.gameObject.SendMessage("applyDamage", enemyData.attackCooldown);
        //    animator.SetBool("isAttacking", false);

        //}
    }


    IEnumerator golemAttackDelay()
    {
        alreadyAttacked = true;
        animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(0.7f);
        //animator.SetBool("isAttacking", false);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.forward, out hit, 2f, ~enemy))
        {
            if(hit.transform.tag == "Player")
            {
                //Debug.Log("Passed");
                if (this.gameObject.layer == 11)
                {
                    hit.transform.gameObject.SendMessage("applyDamage", Random.Range(enemyData.monsterStat[monsterIndex].attackPower - 1, enemyData.monsterStat[monsterIndex].attackPower + 1));
                }
                else
                {
                    hit.transform.gameObject.SendMessage("applyDamage", Random.Range(enemyData.monsterStat[monsterIndex].attackPower + 3, enemyData.monsterStat[monsterIndex].attackPower + 4));
                }
                //hit.transform.gameObject.SendMessage("applyPushback", -transform.forward * enemyData.enemyPushbackPower);
            }
            
            

        }
    }
    private void attacking()
    {
        //agent.SetDestination(target.position);  
        agent.isStopped = true;

        transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z));
 
       
        if (!alreadyAttacked)
        {
            if (enemyType == EnemyType.golem)
            {
                //Debug.Log("Passed");
                StartCoroutine(golemAttackDelay());
                if(this.gameObject.layer == 11)
                {
                    Invoke("ResetAttack", enemyData.monsterStat[monsterIndex].attackCooldown);
                }
                else
                {
                    Invoke("ResetAttack", enemyData.monsterStat[monsterIndex].attackCooldown / 2.0f);
                }
                
            }
            if (enemyType == EnemyType.skeleton)
            {
                StartCoroutine(skeletionAttackDelay());
                if (this.gameObject.layer == 11)
                {
                    Invoke("ResetAttack", enemyData.monsterStat[monsterIndex].attackCooldown);
                }
                else
                {
                    Invoke("ResetAttack", enemyData.monsterStat[monsterIndex].attackCooldown / 2.0f);
                }
            }
           

        }
    }
    private void ResetAttack()
    {
        
        alreadyAttacked = false;
        
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyData.monsterStat[monsterIndex].attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyData.monsterStat[monsterIndex].sightRange);
    }
    // Update is called once per frame

}
