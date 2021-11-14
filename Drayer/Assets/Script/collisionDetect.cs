using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Physics.IgnoreLayerCollision(11, 12);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        Destroy(this.gameObject);
    }
}
