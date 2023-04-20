using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class VirtualCameraController : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (virtualCamera.Follow == null && GameObject.FindWithTag("Player") != null)
        {
            virtualCamera.Follow = GameObject.FindWithTag("Player").transform;
        }
    }
}
