using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumping : MonoBehaviour
{
    Button button;
    GameObject player;


    private void Start()
    {
        button = GetComponent<Button>();
        player = GameObject.FindGameObjectWithTag("Player");
        button.onClick.AddListener(jumpingOnClick);
    }

    void jumpingOnClick()
    {
        player.SendMessage("jumping");
    }
}
