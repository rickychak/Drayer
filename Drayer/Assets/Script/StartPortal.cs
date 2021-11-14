using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPortal : MonoBehaviour
{
    public float totalHealth;
    [SerializeField]
    private GolemData data;
    int monsterIndex;
    GameObject[] enemies;
    public float currTotalHealth;
    GameObject portal;
    void Start()
    {
        for (int i = 0; i < data.monsterStat.Length; i++)
        {
            if (this.gameObject.name == data.monsterStat[i].name)
            {
                monsterIndex = i;
            }
        }
        enemies = GameObject.FindGameObjectsWithTag("Monster");
        totalHealth = enemies.Length * data.monsterStat[monsterIndex].enemyHealth;
        portal = GameObject.FindGameObjectWithTag("Portal");
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        float temperaroyCurrHealth = 0;
        foreach (GameObject enemy in enemies)
        {
            temperaroyCurrHealth += enemy.GetComponent<DamageScript>().currHealth;
        }
        currTotalHealth = temperaroyCurrHealth;

        if (currTotalHealth <= 0)
        {
            portal.SetActive(true);
        }
        
    }
}
