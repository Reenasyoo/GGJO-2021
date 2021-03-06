﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterLocomotion : MonoBehaviour
{
    #region Fields

    [SerializeField] private CharacterContainer container = default;
    [SerializeField] private CharacterSettings settings;
    [SerializeField] private Rigidbody _rigidbody;
    
    
    [SerializeField] private float rotationSpeed = 2f;
    // [SerializeField] private float characterFolowRotationDeadzone = 0.1f;
    
    
    private readonly Vector3 gravity = Physics.gravity;
    private Vector3 inputVelocity = default;
    private Vector3 targetVelocity = default;
    public bool grounded = false;
    
    public float HeightToGround = 0.5f;
    private  float RaycastDistanceOffset = 0.05f;
    private float RaycastDistance = 0;
    private readonly Vector3 downDirection = new Vector3(0, -1, 0);
    private readonly LayerMask ignoreLayers = 1 << 11;
    private bool canJump = true;

    private Vector3 spherePositon = default;
    private Transform mainCamera = null;
    
    #endregion
    
    #region Debug

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spherePositon, 0.05f);
    }

    #endregion


    // Start is called before the first frame update
    private void Start()
    {
        RaycastDistance = HeightToGround + RaycastDistanceOffset;
        _rigidbody.freezeRotation = true;
        // _rigidbody.useGravity = false;
        _rigidbody.angularDrag = 999;
        _rigidbody.drag = 0;

        mainCamera = CameraController.Instance.CameraTransform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        inputVelocity = new Vector3(Input.GetAxis(VARS.HORIZONTAL_STRING), 0, Input.GetAxis(VARS.VERTICAL_STRING)).normalized;
        
        grounded = CheckGrounded();

        if (grounded)
        {
            // Transform directions from local to world space, for safety
            targetVelocity = transform.TransformDirection(inputVelocity);
            targetVelocity *= settings.MovementSpeed;

            _rigidbody.velocity = targetVelocity;
            
            if (canJump && Input.GetButton(VARS.JUMP_STRING))
            {
                canJump = false;
                _rigidbody.velocity = new Vector3(targetVelocity.x, CalculateJumpVerticalSpeed(), targetVelocity.z);
            }
        }
        // Add gravity
        // _rigidbody.AddForce(new Vector3(0, gravity.y * _rigidbody.mass, 0));
        var mass = _rigidbody.mass;
        _rigidbody.AddForce(Physics.gravity * mass);
    }

    private void Update()
    {
        RotateCharacterFowardToCamera();
        
        container.AnimationController.SetForwardVelocity(inputVelocity.z);
    }

    private bool CheckGrounded() // TODO: Should be in collisions controller
    {
        grounded = false;

        var origin = transform.position - (Vector3.up * HeightToGround);
        spherePositon = origin + downDirection * RaycastDistance;

        Debug.DrawRay(origin, downDirection * RaycastDistance, Color.red);
        
        if (!Physics.SphereCast(origin, 0.05f, downDirection, out var raycastHit, RaycastDistance, ignoreLayers))
            return grounded;

        canJump = true;
        grounded = true;

        return grounded;
    }
    
    private float CalculateJumpVerticalSpeed()
    {
        return Mathf.Sqrt(-1 * settings.JumpHeight * gravity.y / _rigidbody.mass); // TODO: Add rounder
    }
    
    private void RotateCharacterFowardToCamera()
    {
        // // TODO: Add switch for different rotation sizes
        var distance = 0f;
        var direction = 0;
        var rotation = transform.rotation;
        var cameraRotation = mainCamera.rotation;


        if (!myApproximation(rotation.y, cameraRotation.y, 0.1f))
        {
            if (rotation.y > cameraRotation.y)
            {
                distance = rotation.y - cameraRotation.y;
                direction = 0;
            
            }
            else if ( rotation.y < cameraRotation.y)
            {
            
                distance = cameraRotation.y - rotation.y;
                direction = 2;
            }
        }
        else
        {
            
            direction = 1;
        }
            

        // If current camera distane is less than deadzone exit method
        // if (!(distance > characterFolowRotationDeadzone)) return;
            
        var rotationTarget =
            Quaternion.Lerp(rotation, cameraRotation, Time.deltaTime * rotationSpeed);
                
        // Remove x and z rotations so character would only rotate in one axes
        rotationTarget.x = 0;
        rotationTarget.z = 0;
                
        // Apply modified rotation
        transform.rotation = rotationTarget;
            
        // Set rotation animation state
        // container.AnimationController.SetCharacterRotationY(direction);
    }
    
    private bool myApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }
    
}
