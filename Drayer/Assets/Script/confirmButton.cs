using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class confirmButton : MonoBehaviour
{
    Button button;
    public GameObject Content;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(pressed);
    }

    // Update is called once per frame
    private void pressed()
    {
        int weaponCat = playerData.weaponType;
        playerData.money -= playerData.weaponPrice[weaponCat - 1];
        Content.transform.GetChild(weaponCat).GetChild(2).gameObject.SetActive(false);
        playerData.weaponBought[weaponCat-1] = true;
    }
}
