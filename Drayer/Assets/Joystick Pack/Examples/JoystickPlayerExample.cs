using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    VariableJoystick variableJoystick;
    public GameObject head;
    Animator animator;
    [SerializeField]
    private PlayerData playerData;
    public float horizontalSensitivity = 0.25f;
    public float headSensitivity = 0.1f;
    public float MaxNeckRotation = 120f;
    public float MinNeckRotation = 30f;
    private float alreadyRotated = 0;
    private bool isIdle = false;
    private bool isWalk = false;
    
    CharacterController CC;

    void Start()
    {
        variableJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VariableJoystick>();
        CC = GetComponent<CharacterController>();
        animator = this.gameObject.GetComponent<Animator>();
        isIdle = animator.GetBool("isIdle");
        isWalk = animator.GetBool("isWalk");

    }
    public void Update()
    {
        //Debug.Log(variableJoystick.Vertical);
        if (variableJoystick.Vertical != 0f && variableJoystick.Horizontal != 0f)
            
        {
           
            isIdle = false;
            isWalk = true;
        }
        else
        {
            isIdle = true;
            isWalk = false;
        }
       
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isWalk", isWalk);
        animator.SetFloat("Horizontal", variableJoystick.Horizontal);
        animator.SetFloat("Vertical", variableJoystick.Vertical);
        animator.SetFloat("animationMultiplier", playerData.speed / 2);
        Vector3 direction = (transform.forward * variableJoystick.Vertical + transform.right * variableJoystick.Horizontal)*playerData.speed;
        CC.Move(direction * Time.deltaTime);

    }


    public void Rotatation(float x, float y)
    {
        Vector3 horizontalRotation = new Vector3(0, horizontalSensitivity * y, 0);
        // Apply the rotation to the rigid body
        CC.transform.Rotate(horizontalRotation);



        var rotation = Mathf.Clamp(headSensitivity * x, MinNeckRotation - alreadyRotated, MaxNeckRotation - alreadyRotated);
        Vector3 headRotation = new Vector3(rotation, 0, 0);
        head.transform.Rotate(headRotation);

        alreadyRotated += rotation;


    }



}