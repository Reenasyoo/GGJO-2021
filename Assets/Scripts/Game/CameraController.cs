using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineBrain brain;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    


    private void SetPlayerCamera()
    {
        // brain.ActiveVirtualCamera = playerCamera;
    }
}
