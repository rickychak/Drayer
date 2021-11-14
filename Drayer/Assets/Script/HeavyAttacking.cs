using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyAttacking : MonoBehaviour
{
    Button button;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        button.onClick.AddListener(attackOnClick);
    }

    // Update is called once per frame
    void attackOnClick()
    {
        player.SendMessage("heavyAttacking");
        

    }
}
