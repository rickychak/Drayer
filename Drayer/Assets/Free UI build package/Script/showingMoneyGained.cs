using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showingMoneyGained : MonoBehaviour
{
    public PlayerData playerData;
    TextMeshProUGUI parentText;
    TextMeshProUGUI childText;

    
    public void showingMoney()
    {
        parentText = GetComponent<TextMeshProUGUI>();
        childText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        playerData.money += playerData.tempMoneyHolder;
        
        parentText.text = playerData.tempMoneyHolder.ToString();
        childText.text = parentText.text;
        playerData.tempMoneyHolder = 0;
    }
}
