using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSetting : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private GameObject shieldField;
    [SerializeField] private GameObject swordField;
    Material _material;
    Renderer _renderer;
    CharacterController CC;
    Animator animator;
    Animator shieldAnimator;
    GameObject panel, deathMenu;
    GameObject moneyText;
    Rigidbody rb;
    
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        shieldAnimator = shieldField.GetComponent<Animator>();
        if (!playerData.skillBoost[2].isSkillOn)
        {
            shieldField.SetActive(false);
        }
        if (!playerData.skillBoost[3].isSkillOn)
        {
            swordField.SetActive(false);
        }
        _material = shieldField.GetComponent<Renderer>().material;
        if (SceneManager.GetActiveScene().name != "MenuScene")
        {
            //GetComponent<SwipeDetect>().enabled = false;
            animator.SetBool("isInMenu", false);
            animator.SetInteger("weaponType", playerData.weaponChoice);
            panel = GameObject.FindGameObjectWithTag("Block");
            deathMenu = GameObject.FindGameObjectWithTag("Dead");
            moneyText = deathMenu.transform.GetChild(2).gameObject;
            deathMenu.SetActive(false);
            panel.SetActive(false);
        }
        else
        {
            animator.SetBool("isInMenu", true);
            GetComponent<JoystickPlayerExample>().enabled = false;
            GetComponent<GroundChecking>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            GetComponent<AttackScript>().enabled = false;
            GetComponent<SteppingPortal>().enabled = false;
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<WeaponInitialise>().enabled = false;
            
        }
        
    }

    
    void applyPushback(Vector3 pusbackPower)
    {
        Debug.Log("A");
        rb.isKinematic = true;
        rb.AddForce(pusbackPower, ForceMode.Impulse);
        rb.isKinematic = false;
    }

    // Update is called once per frame

   
    void applyDamage(float dmg)
    {
        if (playerData.skillBoost[2].isSkillOn)
        {
            float guardedDmg = (dmg - playerData.playerArmor);

            //Debug.Log(_material.GetFloat("_Opacity"));
            shieldAnimator.SetTrigger("Guarding");
            if (guardedDmg >= 0)
            {
                playerData.currHealth -= guardedDmg;
            }
            else
            {
                playerData.currHealth -= Mathf.Round(Random.Range(0.01f, 0.1f) * 10.0f) / 10.0f;
            }
            
        }
        else
        {
            playerData.currHealth -= dmg;
        }
        
        if (playerData.currHealth <= 0)
        {
            StartCoroutine(DeathMenuThreeSecondsDelay());
        }

    }
    IEnumerator DeathMenuThreeSecondsDelay()
    {
        
        JoystickPlayerExample jpe = GetComponent<JoystickPlayerExample>();
        GroundChecking GC = GetComponent<GroundChecking>();
        GC.enabled = false;
        jpe.enabled = false;
        panel.SetActive(true); 
        CC = GetComponent<CharacterController>();
        CC.enabled = false;
        animator.SetTrigger("isDead");
        moneyText.GetComponent<showingMoneyGained>().showingMoney();
        yield return new WaitForSeconds(3.0f);
        deathMenu.GetComponent<DeathMenu>().popUp();

    }
    

}
