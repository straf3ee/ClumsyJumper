using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody _rigidbody;

    [SerializeField] 
    private float _jumpForce = 300f;

   [SerializeField] 
    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpdate(collision, true);
    }
    
    private void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }
    
    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            _isGrounded = value;
        }
    }
}