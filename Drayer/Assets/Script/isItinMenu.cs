using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isItinMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MenuScene")
        {
            GetComponent<JoystickPlayerExample>().enabled = false;
            GetComponent<GroundChecking>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<AttackScript>().enabled = false;
            GetComponent<SteppingPortal>().enabled = false;
            GetComponent<HealthSetting>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
        }
    }

  
}
