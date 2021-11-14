using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{

    public void popUp()
    {
        this.gameObject.SetActive(true);
        this.gameObject.GetComponent<Animator>().SetBool("PopUp", true);
    }
}
