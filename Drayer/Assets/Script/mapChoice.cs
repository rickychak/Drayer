using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mapChoice : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject _parent;
    Button button;
    int stageNo;
    private void Start()
    {
        stageNo = _parent.transform.childCount;
        button = GetComponent<Button>();
        button.onClick.AddListener(clicking);
    }


    // load scene based on what player clicked -R
    void clicking()
    {
        for(int i=0; i<stageNo; i++)
        {
            //Debug.Log(this.transform.parent.name);
            if (_parent.transform.GetChild(i).name == this.transform.parent.name)
            {
                playerData.stageChosen = (i+1);
                playerData.currHealth = playerData.health;
                SceneManager.LoadScene("Stage" + (i + 1).ToString() + "-1");
            }
        }
    }
}
