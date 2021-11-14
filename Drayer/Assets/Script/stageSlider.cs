using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class stageSlider : MonoBehaviour
{
    Slider slider;
    public PlayerData playerData;
    public GameObject parent;
    int stageNo;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        stageNo = parent.transform.childCount;
        slider = GetComponent<Slider>();
        for (int i = 0; i < stageNo; i++)
        {
            if (parent.transform.GetChild(i).name == this.gameObject.transform.parent.parent.name)
            {
                
                slider.value = playerData.stageProcess[i] / 5.0f;
                text.text = playerData.stageProcess[i].ToString() + " / 5";
                
            }
        }
    }

    
}
