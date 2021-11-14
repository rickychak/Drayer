using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearBought : MonoBehaviour
{
    Button button;
    public GameObject confirmPanel;
    public GameObject rejectPanel;
    public PlayerData playerData;

    private void Start()
    {
        if (playerData.weaponBought[1])
        {
            this.gameObject.SetActive(false);
        }
        button = GetComponent<Button>();
        button.onClick.AddListener(buying);
    }

    private void buying()
    {
        if (playerData.money >= 200)
        {
            playerData.weaponType = 2;
            confirmPanel.SetActive(true);
        }
        else
        {
            rejectPanel.SetActive(true);
        }

        /*if (playerData.money >= 50)
        {
            playerData.money -= 50;
            this.gameObject.SetActive(false);
            playerData.axeBought = true;
        }
        else
        {
            Debug.Log("Not enough money");
        }*/
    }
}
