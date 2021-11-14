using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;

public class SpinningButton : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private Text uiSpinButtonText;
    [SerializeField] private PickerWheel pickerWheel;
    [SerializeField] private PlayerData playerData;
    GameObject confirmScene;
    // Start is called before the first frame update
    void Start()
    {
        confirmScene = this.transform.parent.GetChild(2).gameObject;
        confirmScene.SetActive(false);
        uiSpinButton.onClick.AddListener(() =>
        {
            uiSpinButton.interactable = false;
            uiSpinButtonText.text = "Spinning";

            pickerWheel.OnSpinEnd(WheelPiece =>{
                playerData.skillBoost[WheelPiece.id].isSkillOn = true;
                StartCoroutine(delay());
            });
            pickerWheel.Spin();
        });
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        confirmScene.SetActive(true);
    }
    
}
