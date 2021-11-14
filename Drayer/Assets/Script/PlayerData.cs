using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    // Start is called before the first frame update
    
    public float speed;
    public float attackPower, heavyPower;
    public float playerArmor;
    public float attackCD, heavyCD;
    public float pushback;
    public float attackRange, heavyRange;
    public float health;
    public float currHealth;
    public float tempMoneyHolder, money;
    public int weaponType;
    public int weaponChoice;
    public bool[] weaponBought = { false, false };
    public int[] weaponPrice = { 50, 100 };
    public int[] stageProcess;
    public int stageChosen;
    public skillCD[] skillBoost;
    public weaponStat[] _weaponStat;

}

[System.Serializable]
public struct skillCD
{
    public string skillName;
    public int skillDuration;
    public bool isSkillOn;
}
[System.Serializable]
public struct weaponStat
{
    public string weaponName;
    public float speed;
    public float attackPower;
    public float heavyPower;
    public float attackCD;
    public float heavyCD;
    public float attackRange;
    public float heavyRange;
}