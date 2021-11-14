using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    Slider slider;
    float health;
    float currHealth;
    GameObject character;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("EnemyHealth");
        

        slider = this.gameObject.GetComponent<Slider>();
        slider.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 5)
        {
            slider.value = 1.0f;
            count++;

        }
        if (slider.value > 0.0f)
        {

            health = character.GetComponent<StartPortal>().totalHealth;
            currHealth = character.GetComponent<StartPortal>().currTotalHealth;
            slider.value = currHealth / health;
        }
        
    }

}
