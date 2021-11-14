using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyBoardInput : MonoBehaviour
{
    public CharacterController CC;
    float speed = 2.0f;
    public Animator animator;
    bool isIdle;
    bool isWalk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime;
        float y = Input.GetAxis("Vertical") * Time.deltaTime;
        
        if (x != 0f && y != 0f)
        {
            isIdle = false;

        }
        else
        {
            isIdle = true;
        }
        Vector3 move = (transform.right * x + transform.forward * y)*speed;
        CC.Move(move);
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isWalk", isWalk);
        animator.SetFloat("Horizontal", x * 100);
        animator.SetFloat("Vertical", y * 100);

    }
}
