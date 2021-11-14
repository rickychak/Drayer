using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInitialise : MonoBehaviour
{
    public GameObject hand;
    public PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        //Set every weapon inactive first -R
        for(int i=0; i < 3; i++)
        {
            hand.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        //finding which weapon player selected -R
        int weaponChoice = playerData.weaponChoice;

        //Set the selected weapon model in character prefab active -R
        hand.transform.GetChild(weaponChoice).gameObject.SetActive(true);
        
        //Assign the stat of the weapon to game scene -R
        playerData.speed = playerData._weaponStat[weaponChoice].speed;
        playerData.attackPower = playerData._weaponStat[weaponChoice].attackPower;
        playerData.heavyPower = playerData._weaponStat[weaponChoice].heavyPower;
        playerData.attackRange = playerData._weaponStat[weaponChoice].attackRange;
        playerData.heavyRange = playerData._weaponStat[weaponChoice].heavyRange;
        playerData.attackCD = playerData._weaponStat[weaponChoice].attackCD;
        playerData.heavyCD = playerData._weaponStat[weaponChoice].heavyCD;
                

        
    }

    
}
