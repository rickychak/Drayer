using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cinemachineFollowing : MonoBehaviour
{
    CinemachineVirtualCamera Vcam;
    // Start is called before the first frame update
    void Start()
    {
        Vcam = GetComponent<CinemachineVirtualCamera>();
        Vcam.m_Follow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;
    }

    


}
