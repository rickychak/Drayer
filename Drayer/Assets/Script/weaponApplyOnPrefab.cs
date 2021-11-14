using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class weaponApplyOnPrefab : MonoBehaviour
{
    public GameObject weaponInPrefab;
    public GameObject Player;
    public GameObject PlayerPrefab;
    Mesh weaponMesh;
    Button button;
    // Start is called before the first frame update
    private void Start()
    {
        weaponMesh = this.transform.GetChild(0).GetComponent<MeshFilter>().mesh;
        button = GetComponent<Button>();
        button.onClick.AddListener(changingWeapon);
    }

    // Update is called once per frame
    public void changingWeapon()
    {
        weaponInPrefab.GetComponent<MeshFilter>().mesh = weaponMesh;
        //EditorUtility.SetDirty(Player);
        PrefabUtility.RecordPrefabInstancePropertyModifications(PlayerPrefab);
        //Debug.Log(AssetDatabase.GetAssetPath(PlayerPrefab));
    }
}
