using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    Animator animator;
    GameObject thisCamera;
    public LayerMask ignoreMask;
    [SerializeField]
    private PlayerData playerData;
    private float nextAttack;
    private float nextHeavyAttack;
    public Vector3 raycastHitPosition;
    Image hitCrosshair;
    public GameObject fireBullet;
    public GameObject iceBullet;
    private void Start()
    {
        thisCamera = GameObject.FindGameObjectWithTag("Camera");
        animator = this.gameObject.GetComponent<Animator>();
        hitCrosshair = GameObject.FindGameObjectWithTag("Crosshair").GetComponent<Image>();
        hitCrosshair.enabled = false;   
    }
    // Start is called before the first frame update

    
    // this function is for player pressing attack button and call this function with Cooldown calculation -R
    public void attacking()
    {
        if (Time.time > nextAttack)
        {
            nextAttack = Time.time + playerData.attackCD;
            StartCoroutine(attackDelay());
        } 
    }

    // play hit animation for crosshair when attack hit -R
    IEnumerator crosshairAnimation()
    {
        hitCrosshair.enabled = true;
        yield return new WaitForSeconds(0.3f);
        hitCrosshair.enabled = false;
    }
    
    //syncing animation and attack timing, call damage function from the enemy -R
    IEnumerator attackDelay()
    {
        animator.SetTrigger("AttackButtonIsClicked");
        yield return new WaitForSeconds(0.3f);
        RaycastHit hit;
        
        bool isHit = Physics.Raycast(thisCamera.transform.position, thisCamera.transform.forward, out hit, playerData.attackRange, ~ignoreMask);
        if (isHit)
        {
            //Debug.Log("Hit");
            if (hit.transform.tag == "Monster")
            {
                raycastHitPosition = hit.point;
                float[] power = { playerData.attackPower, playerData.pushback };
                hit.transform.SendMessage("applyAttackDmg", power);
                StartCoroutine(crosshairAnimation());
            }
            
        }
    }

    // this function is for player pressing heavy attack button and call this function with Cooldown calculation -R
    public void heavyAttacking()
    {
        if (Time.time > nextHeavyAttack)
        {
            nextHeavyAttack = Time.time + playerData.heavyCD;
            StartCoroutine(heavyAttackDelay());
        }
    }

    //syncing animation and heavy attack timing, call heavy attack damage/ skill effect from enemy -R
    IEnumerator heavyAttackDelay()
    {
        animator.SetTrigger("HeavyAttackIsClicked");
        yield return new WaitForSeconds(1.2f);
        RaycastHit heavyHit;
        bool isHeavyHit = Physics.Raycast(thisCamera.transform.position, thisCamera.transform.forward, out heavyHit, playerData.heavyRange, ~ignoreMask);
        skillImplementation();
        if (isHeavyHit)
        {
            if (heavyHit.transform.tag == "Monster")
            {
                float[] power = { playerData.heavyPower, playerData.pushback*2 };
                heavyHit.transform.SendMessage("applyAttackDmg", power);
                StartCoroutine(crosshairAnimation());
            }
        }
    }
   

    // 2 projectile skills - fire and ice -R
    private void skillImplementation()
    {
        if(playerData.skillBoost[0].isSkillOn == true)
        {
            GameObject firebullet = Instantiate(fireBullet, transform.position + new Vector3(0,1.3f,0)  + thisCamera.transform.forward * 1f, transform.rotation);
            firebullet.GetComponent<Rigidbody>().AddForce(thisCamera.transform.forward * 10.0f, ForceMode.Impulse);
        }
        if(playerData.skillBoost[1].isSkillOn == true)
        {
            GameObject icebullet = Instantiate(iceBullet, transform.position + new Vector3(0, 1.5f, 0) + thisCamera.transform.forward * 1f, transform.rotation);
            icebullet.GetComponent<Rigidbody>().AddForce(thisCamera.transform.forward * 10.0f, ForceMode.Impulse);
        }
    }
    
    
    
}
