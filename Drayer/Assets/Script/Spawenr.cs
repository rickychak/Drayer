using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawenr : MonoBehaviour
{
    
    public GameObject enemy;
    public GameObject bossEnemy;
    public GameObject player;
    public GameObject playerLocation;
    int stageNo;
    /*GameObject activatingEnemy;
    GameObject activatingPlayer;*/
    // Start is called before the first frame update
    void Awake()
    {
   
        //GameObject activatingEnemy1 = Instantiate(enemy, enemyLocation.transform.position+ new Vector3(1,0,0), Quaternion.identity);
        //activatingEnemy.SetActive(true);
        string sceneName = SceneManager.GetActiveScene().name;
        stageNo = sceneName[sceneName.Length-1] - '0';

        GameObject _player = Instantiate(player, playerLocation.transform.position, Quaternion.Euler(0, 180, 0));
        //activatingPlayer.SetActive(true);
        switch (stageNo){
            case 1:
                Instantiate(enemy, new Vector3(Random.Range(20, 40), 6, -63.23f), Quaternion.identity);
                break;
            case 2:
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(20, 40), 6, -63.23f), Quaternion.identity);
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(20, 40), 6, -63.23f), Quaternion.identity);
                }
                break;
            case 4:
                for (int i = 0; i < 8; i++)
                {
                    Instantiate(enemy, new Vector3(Random.Range(20, 40), 6, -63.23f), Quaternion.identity);
                }
                break;
            case 5:
                Instantiate(bossEnemy, new Vector3(30, 6, -50), Quaternion.identity);
                break;
        }

        

    }


}
