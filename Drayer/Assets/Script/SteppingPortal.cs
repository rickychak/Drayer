using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SteppingPortal : MonoBehaviour
{
    int stageNo;
    public PlayerData playerData;
    GameObject skillBoostScene;
    private void Start()
    {
        skillBoostScene = GameObject.FindGameObjectWithTag("SkillBoost");
        skillBoostScene.SetActive(false);
        stageNo = SceneManager.GetActiveScene().name[SceneManager.GetActiveScene().name.Length - 1] - '0';
        //Debug.Log("Stage" + playerData.stageChosen.ToString() + "-" + (stageNo + 1).ToString());
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.transform.tag == "Portal")
        {
            //Debug.Log(stageNo);
            playerData.stageProcess[playerData.stageChosen - 1] = stageNo;
            if (stageNo != 5)
            {
                if(stageNo==1 || stageNo == 4)
                {
                    skillBoostScene.SetActive(true);
                }
                else
                {
                    SceneManager.LoadScene("Stage" + playerData.stageChosen.ToString() + "-" + (stageNo + 1).ToString());
                }
                
                
            }
            else
            {
                SceneManager.LoadScene("MenuScene");
            }
            
        }
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage" + playerData.stageChosen.ToString() + "-" + (stageNo + 1).ToString());
    }

}
