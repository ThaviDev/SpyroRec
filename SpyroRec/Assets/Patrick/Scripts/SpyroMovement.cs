
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpyroMovement : MonoBehaviour
{
    public float _moveSpeed;
    public float _rotationSpeed;
    public float _jumpSpeed;

    private CharacterController _characterController;
    private float _ySpeed;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3 (horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * _moveSpeed;
        movementDirection.Normalize ();

        _ySpeed += Physics.gravity.y * Time.deltaTime;

        if (_characterController.isGrounded)
        {
            _ySpeed = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                _ySpeed = _jumpSpeed;
            }
        }

        Vector3 _velocity = movementDirection * magnitude;
        _velocity.y = _ySpeed;

        _characterController.Move(_velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero) 
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}
