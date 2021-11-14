using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    private void Update()
    {

        Destroy(this.gameObject, 2.0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Monster")
        {
            collision.transform.SendMessage("applyEffect", collision.GetContact(0).point);

        }
        
        Destroy(this.gameObject);
        
       

    }
}
