using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class menuChangingMoney : MonoBehaviour
{
    public PlayerData playerData;
    TextMeshProUGUI mText;
    private void Start()
    {
        mText = GetComponent<TextMeshProUGUI>();
        mText.text = (playerData.money).ToString();
    }
}
