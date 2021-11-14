using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    Rigidbody rb;
    bool grounded;
    Animator animator;
    CharacterController CC;
    private float verticalVel;

    
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        CC = GetComponent<CharacterController>();
        //DontDestroyOnLoad(this.gameObject);
    }
    void Update()
    {
        groundCheck();
    }
    
    public void groundCheck()
    {
        int colliderCount = 0;
        Debug.DrawRay(transform.position, Vector3.down*0.1f, Color.red);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.3f);
        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.transform.tag == "GroundCheck")
            {
                colliderCount += 1;
            }
        }
        if (colliderCount > 0)
        {
            //verticalVel = -9.81f * Time.deltaTime;
            //Debug.Log("Grounded");
            grounded = true;
            animator.SetBool("grounded", true);
        }
        else
        {
            verticalVel -= 9.81f * Time.deltaTime;
            //Debug.Log("Not grounded");
            grounded = false;
            animator.SetBool("grounded", false);
        }
        Vector3 moveVec = new Vector3(0, verticalVel, 0);
        CC.Move(moveVec * Time.deltaTime);
    }

    IEnumerator oneSecondDelay()
    {
        animator.SetTrigger("IsGrounded");
        yield return new WaitForSeconds(0.6f);
        verticalVel = 5.0f;
    }
    public void jumping()
    {
        if (grounded)
        {
            
            
            StartCoroutine(oneSecondDelay());
            
        }
    }
   
    
}
