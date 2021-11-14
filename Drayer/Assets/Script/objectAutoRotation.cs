using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAutoRotation : MonoBehaviour
{
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,1,0),0.1f);
    }
}
