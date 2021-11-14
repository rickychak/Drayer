using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneStage : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void LoadStage1()
    {
        //playerData.currHealth = playerData.health;
        SceneManager.LoadScene("Stage1-1");
    }
    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage1-2");
    }
}
