using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup1 : MonoBehaviour
{
    public GameObject imageCover;
    public GameObject anotherCover;
    public GameObject mapMenu;
    public GameObject anotherMenu;
    Button button;
    private void Start()
    {

        button = GetComponent<Button>();
        button.onClick.AddListener(showMapMenu);
        imageCover.SetActive(false);
    }


    private void showMapMenu()
    {
        imageCover.SetActive(true);
        anotherCover.SetActive(false);
        mapMenu.SetActive(true);
        anotherMenu.SetActive(false);
    }

}
