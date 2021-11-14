using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    Slider slider;
    float health;
    float _currHealth;
    [SerializeField]
    private PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        health = playerData.health;
        
        slider = this.gameObject.GetComponent<Slider>();
        slider.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value > 0.0f)
        {
            _currHealth = playerData.currHealth;
            slider.value = _currHealth/health;
        }
    }

}
