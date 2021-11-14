using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressPanel : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            GameObject.FindGameObjectWithTag("Player").SendMessage("NextStage");
        });
    }

    
}
