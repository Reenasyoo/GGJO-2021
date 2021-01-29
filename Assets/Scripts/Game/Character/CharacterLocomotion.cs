using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterLocomotion : MonoBehaviour
{
    #region Fields

    [SerializeField] private CharacterContainer container = default;
    [SerializeField] private CharacterSettings settings;
    [SerializeField] private Rigidbody _rigidbody;
    
    
    private readonly Vector3 gravity = Physics.gravity;
    private Vector3 inputVelocity = default;
    private Vector3 targetVelocity = default;
    
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
        _rigidbody.angularDrag = 999;
        _rigidbody.drag = 0;

        // velocity = _rigidbody.velocity;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        inputVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

        // Transform directions from local to world space, for safety
        targetVelocity = transform.TransformDirection(inputVelocity);
        targetVelocity *= settings.MovementSpeed;

        _rigidbody.velocity = targetVelocity;
        
        _rigidbody.AddForce(new Vector3(0, gravity.y * _rigidbody.mass, 0));
    }
}
