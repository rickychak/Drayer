using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCap : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            screenshot.TakeScreenshot_Static(900   ,900);
        }
    }
}
