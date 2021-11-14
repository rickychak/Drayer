using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class DamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GolemData data;
    [SerializeField] private GameObject damageDisplayParent;
    [SerializeField] private GameObject icingEffect;
    
    GameObject player;
    AttackScript AS;
    ParticleSystem ps;
    Renderer _renderer;
    int monsterIndex;
    public float currHealth;
    public PlayerData playerData;
    public bool pushingBack;
    public List<int> burnTickTimers = new List<int>();
    private void Start()
    {
        icingEffect.SetActive(false);
        for (int i = 0; i < data.monsterStat.Length; i++)
        {
            if (this.gameObject.name == data.monsterStat[i].name)
            {
                monsterIndex = i;
            }
        }
        
        _renderer = transform.GetChild(1).GetComponent<Renderer>();
        _renderer.material = Instantiate(_renderer.material);
        player = GameObject.FindGameObjectWithTag("Player");
        AS = player.GetComponent<AttackScript>();
        currHealth = data.monsterStat[monsterIndex].enemyHealth;
    }
    IEnumerator threeSecondsDelay()
    {
        yield return new WaitForSeconds(3.0f);
        this.gameObject.SetActive(false);
    }


    IEnumerator transformBackward(float endTime)
    {
    
        for (float time = 0f; time <= endTime; time += 0.1f)
        {
            transform.position += Vector3.back * Time.deltaTime * Mathf.Sqrt(Mathf.Pow((time- endTime),2))/ endTime;
            yield return null;
          
        }
    }


    void applyAttackDmg(float[] power)
    {
        
        Vector3 rayHitPosition = AS.raycastHitPosition;
        TextMeshPro damage = Instantiate(damageDisplayParent, rayHitPosition, Quaternion.LookRotation(player.transform.position - transform.position) * Quaternion.Euler(0, 180, 0)).GetComponentInChildren<TextMeshPro>();
        damage.text = power[0].ToString();
        currHealth -= power[0];
        StartCoroutine(transformBackward(power[1]));
     


        if (currHealth <= 0)
        {
            StartCoroutine(threeSecondsDelay());
        }
        
    }
    
    
    void applyFireDamage()
    {
        
        Vector3 rayHitPosition = AS.raycastHitPosition;
        TextMeshPro damage = Instantiate(damageDisplayParent, rayHitPosition, Quaternion.LookRotation(player.transform.position - transform.position) * Quaternion.Euler(0, 180, 0)).GetComponentInChildren<TextMeshPro>();
        float attackDamage = Random.Range(playerData.heavyPower - 1.0f, playerData.heavyPower + 0.5f);
        damage.text = attackDamage.ToString();
        currHealth -= attackDamage;

        
    }

    void applyEffect(Vector3 hitPosition)
    {
        
        TextMeshPro damage = Instantiate(damageDisplayParent, hitPosition, Quaternion.LookRotation(player.transform.position - transform.position) * Quaternion.Euler(0, 180, 0)).GetComponentInChildren<TextMeshPro>();
        float attackDamage = Mathf.Round(Random.Range(Mathf.Sqrt(playerData.heavyPower) - 1.0f, Mathf.Sqrt(playerData.heavyPower) + 0.5f)*10.0f)/10.0f;
        damage.text = attackDamage.ToString();
        currHealth -= attackDamage;
        if(playerData.skillBoost[0].isSkillOn)
        {
            if (Random.Range(0.0f, 1.0f) > 0.5f)
            {
                if (burnTickTimers.Count <= 0)
                {
                    burnTickTimers.Add(playerData.skillBoost[0].skillDuration);
                    StartCoroutine(Burn());
                }
                else
                {
                    burnTickTimers.Add(playerData.skillBoost[0].skillDuration);
                }
            }
        }
        if (playerData.skillBoost[1].isSkillOn)
        {
            StartCoroutine(Freeze());
        }
        
        
        

    }
    
    IEnumerator Freeze()
    {
        icingEffect.SetActive(true);
        ps = icingEffect.GetComponent<ParticleSystem>();
        ps.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        var main = ps.main;
        main.duration = playerData.skillBoost[1].skillDuration;
        ps.Play();
        data.monsterStat[monsterIndex].enemySpeed /= 2;
        yield return new WaitForSeconds(playerData.skillBoost[1].skillDuration);
        icingEffect.SetActive(false);
        data.monsterStat[monsterIndex].enemySpeed *= 2;
    }
    IEnumerator Burn()
    {
        _renderer.material.color = new Color32(255, 96, 96, 255);
        
        while (burnTickTimers.Count > 0)
        {
            yield return new WaitForSeconds(1.5f);
            for (int i=0; i<burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            float burnDamge = Mathf.Round(Random.Range(playerData.heavyPower/10 - 0.1f, playerData.heavyPower/10)*10.0f)/10.0f;
            currHealth -= burnDamge;
            TextMeshPro damage = Instantiate(damageDisplayParent, transform.localPosition + new Vector3(0,3.5f,0)   , Quaternion.LookRotation(player.transform.position - transform.position) * Quaternion.Euler(0, 180, 0)).GetComponentInChildren<TextMeshPro>();
            damage.text = burnDamge.ToString();
            damage.color = new Color32(233, 78, 78, 255);
            burnTickTimers.RemoveAll(element => element == 0);
            //yield return new WaitForSeconds(1.5f);
        }
        _renderer.material.color = new Color32(255, 255, 255, 255);
    }
   
    
    
}
