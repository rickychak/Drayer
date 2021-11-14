using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosingAxe : MonoBehaviour
{
    public GameObject weapon;
    public PlayerData playerData;
    Button button;
    
    Mesh weaponMesh;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(pressed);
    }

    // Update is called once per frame
    private void pressed()
    {
        playerData.weaponChoice = 1;
        for(int i =0; i<3; i++)
        {
            weapon.transform.GetChild(i).gameObject.SetActive(false);
        }
        weapon.transform.GetChild(1).gameObject.SetActive(true);

    }
}
