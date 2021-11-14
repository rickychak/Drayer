using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    Button btn;
    [SerializeField] private PlayerData playerData;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(MenuPage);

    }

    // disable all the skill boost and return back to menu scene
    void MenuPage()
    {
        for (int j = 0; j < playerData.skillBoost.Length; j++)
        {
            playerData.skillBoost[j].isSkillOn = false;
        }
        SceneManager.LoadScene("MenuScene");
    }
}
