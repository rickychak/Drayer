using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findingWeaponMesh : MonoBehaviour
{
    Mesh weaponMesh;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        weaponMesh = player.GetComponent<MeshFilter>().mesh;
        GetComponent<MeshFilter>().mesh = weaponMesh;
    }

    // Update is called once per frame
    
}
