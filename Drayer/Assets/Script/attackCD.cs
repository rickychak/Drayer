using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heavyCD : MonoBehaviour
{
    float heavyAttackCD;
    [SerializeField]
    private PlayerData data;
    Image redImage;
    bool cooldown = false;
    Button btn;
    void Start()
    {
        heavyAttackCD = data.heavyCD;
        redImage = GetComponent<Image>();
        btn = GetComponentInParent<Button>();
        redImage.fillAmount = 0;
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
            redImage.fillAmount -= 1 / heavyAttackCD * Time.deltaTime;
            if (redImage.fillAmount == 0)
            {
                cooldown = false;
                btn.enabled = true;
            }
        }
        
        
        
    }
}
