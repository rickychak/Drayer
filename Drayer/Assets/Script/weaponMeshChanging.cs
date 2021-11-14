using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMeshChanging : MonoBehaviour
{
    Mesh currentMesh;
    // Start is called before the first frame update
    void Start()
    {
        currentMesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    public void changingWeapon(Mesh weaponPrefabMesh)
    {
        currentMesh = weaponPrefabMesh;
    }
}
