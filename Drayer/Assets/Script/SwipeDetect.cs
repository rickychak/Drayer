using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{
    public float sensitivity = 1;
    public void Rotation(float x, float y)
    {
        transform.Rotate(0, y * sensitivity, 0);
    }

}

