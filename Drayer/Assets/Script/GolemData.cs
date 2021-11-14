using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GolemData : ScriptableObject
{
    public MonsterStat[] monsterStat;
}

[System.Serializable]
public struct MonsterStat
{
    public string name;
    public float enemyHealth;
    public float attackCooldown;
    public float attackPower;
    public float enemySpeed;
    public float enemyPushbackPower;
    public float sightRange, attackRange;
}
