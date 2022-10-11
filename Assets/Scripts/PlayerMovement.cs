using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _jumpForce = 10;

    [SerializeField]
    private bool _onGround = true;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _onGround)
        {
            _onGround = false;
            Debug.Log("Jump");
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Block"))
        {
            _onGround = true;
        }
    }
}
