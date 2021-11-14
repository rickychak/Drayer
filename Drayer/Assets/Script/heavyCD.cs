using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackCD : MonoBehaviour
{
    float AttackCD;
    [SerializeField]
    private PlayerData data;
    Image redImage;
    bool cooldown = false;
    Button btn;
    void Start()
    {
        AttackCD = data.attackCD;
        redImage = GetComponent<Image>();
        redImage.fillAmount = 0;
        btn = GetComponentInParent<Button>();
    }

    public void triggering()
    {
        cooldown = true;
        redImage.fillAmount = 1;
        btn.enabled = false;
    }
    // Update is called once per frame 
    private void Update()
    {

        if (cooldown)
        {
            //Debug.Log(redImage.fillAmount);
            redImage.fillAmount -= 1 / AttackCD * Time.deltaTime;
            if (redImage.fillAmount == 0)
            {
                cooldown = false;
                btn.enabled = true;
            }
        }
        
        
        
    }
}
