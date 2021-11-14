using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordSkill : MonoBehaviour
{
    [SerializeField] LayerMask monster;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Monster")
        {
            Debug.Log("YES"); 
            other.gameObject.SendMessage("applyEffect", new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));
        }
    }
}
