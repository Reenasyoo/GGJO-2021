﻿using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Properties
    public static CameraController Instance { get; private set; } = null;
    public Transform CameraTransform => mainCameraTransform;
    
    #endregion

    #region Fields
    
    [SerializeField] private Transform mainCameraTransform = null;
    [SerializeField] private Camera mainCamera = null;
    
    [Header("Cinemachine")]
    [SerializeField] private CinemachineBrain brain;
    [SerializeField] private CinemachineFreeLook playerCamera;
    [SerializeField] private CinemachineVirtualCamera interactionCamera;

    [SerializeField] private LayerMask interactableButtonLayer = 0;
    
    private Ray ray;
    private RaycastHit hit;
    
    
    #endregion

    #region Init
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    #endregion

    private void Update()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, interactableButtonLayer))
        {
            if (Input.GetMouseButtonDown(0) && GameManager.Instance.CanPress)
            {
                print("wusup");
                var button = hit.collider.gameObject.GetComponent<InteractableButtonController>();
                
                GameManager.Instance.PuzzleButtonPressed = button.buttonIndex;
                GameManager.Instance.CheckPressedButton();
            }
                
        }
    }

    public void SetPlayerCamera()
    {
        playerCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void SetFocus()
    {
        Cursor.lockState = CursorLockMode.None;
        playerCamera.gameObject.SetActive(false);
    }
}
