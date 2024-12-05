
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{
//    [SerializeField]
//    private float rotationSpeed;

//    [SerializeField]
//    private float jumpSpeed;

//    [SerializeField]
//    private float jumpButtonGracePeriod;

//    [SerializeField]
//    private float jumpHorizontalSpeed;

//    [SerializeField]
//    private Transform cameraTransform;

//    private Animator animator;
//    private CharacterController characterController;
//    private float ySpeed;
//    private float originalStepOffset;
//    private float? lastGroundedTime;
//    private float? jumpButtonPressedTime;
//    private bool isJumping;
//    private bool isGrounded;

//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        characterController = GetComponent<CharacterController>();
//        originalStepOffset = characterController.stepOffset;
//    }

//    void Update()
//    {
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
//        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

//        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
//        {
//            inputMagnitude /= 2;
//        }

//        animator.SetFloat("InputMagnitude", inputMagnitude, 0.05f, Time.deltaTime);

//        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
//        movementDirection.Normalize();

//        ySpeed += Physics.gravity.y * Time.deltaTime;

//        if (characterController.isGrounded)
//        {
//            lastGroundedTime = Time.time;
//        }

//        if (Input.GetButtonDown("Jump"))
//        {
//            jumpButtonPressedTime = Time.time;
//        }

//        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
//        {
//            characterController.stepOffset = originalStepOffset;
//            ySpeed = -0.5f;
//            animator.SetBool("IsGrounded", true);
//            isGrounded = true;
//            animator.SetBool("IsJumping", false);
//            isJumping = false;
//            animator.SetBool("IsFalling", false);

//            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
//            {
//                ySpeed = jumpSpeed;
//                animator.SetBool("IsJumping", true);
//                isJumping = true;
//                jumpButtonPressedTime = null;
//                lastGroundedTime = null;
//            }
//        }
//        else
//        {
//            characterController.stepOffset = 0;
//            animator.SetBool("IsGrounded", false);
//            isGrounded = false;

//            if ((isJumping && ySpeed < 0) || ySpeed < -2)
//            {
//                animator.SetBool("IsFalling", true);
//            }
//        }

//        if (movementDirection != Vector3.zero)
//        {
//            animator.SetBool("IsMoving", true);

//            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

//            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
//        }
//        else
//        {
//            animator.SetBool("IsMoving", false);
//        }

//        if (isGrounded == false)
//        {
//            Vector3 velocity = movementDirection * inputMagnitude * jumpHorizontalSpeed;
//            velocity.y = ySpeed;

//            characterController.Move(velocity * Time.deltaTime);
//        }
//    }

//    private void OnAnimatorMove()
//    {
//        if (isGrounded)
//        {
//            Vector3 velocity = animator.deltaPosition;
//            velocity.y = ySpeed * Time.deltaTime;

//            characterController.Move(velocity);
//        }
//    }

//    private void OnApplicationFocus(bool focus)
//    {
//        if (focus)
//        {
//            Cursor.lockState = CursorLockMode.Locked;
//        }
//        else
//        {
//            Cursor.lockState = CursorLockMode.None;
//        }
//    }
//}

public class SpyroMovement : MonoBehaviour
{
    public float _maxMoveSpeed;
    public float _rotationSpeed;
    public float _jumpSpeed;

    [SerializeField]
    private Transform _cameraTransform;

    private Animator _animator;
    private CharacterController _characterController;
    private float _ySpeed;
    private bool _isJumping;
    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 _movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float _inputMagnitude = Mathf.Clamp01(_movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button0))
        {
            _inputMagnitude = 3;
        }
        _animator.SetFloat("Input Magnitude", _inputMagnitude, 0.05f, Time.deltaTime);

        float _moveSpeed = _inputMagnitude * _maxMoveSpeed;
        _movementDirection = Quaternion.AngleAxis(_cameraTransform.rotation.eulerAngles.y, Vector3.up) * _movementDirection;
        _movementDirection.Normalize();

        _ySpeed += Physics.gravity.y * Time.deltaTime;

        if (_characterController.isGrounded)
        {
            _ySpeed = -1f;
            _animator.SetBool("IsGrounded", true);
            _isGrounded = true;
            _animator.SetBool("IsGrounded", true);
            _isGrounded = true;
            _animator.SetBool("IsJumping", false);
            _isJumping = false;
            _animator.SetBool("IsFalling", false);


            if (Input.GetButtonDown("Jump"))
            {
                _ySpeed = _jumpSpeed;
                _animator.SetBool("IsJumping", true);
                _isJumping = true;
            }
        }
        else
        {
            _animator.SetBool("IsGrounded", false);
            _isGrounded = false;

            if ((_isJumping && _ySpeed < 0) || _ySpeed > -2)
            {
                _animator.SetBool("IsFalling", true);
            }
        }

        Vector3 _velocity = _movementDirection * _moveSpeed;
        _velocity.y = _ySpeed;

        _characterController.Move(_velocity * Time.deltaTime);

        if (_movementDirection != Vector3.zero)
        {
            _animator.SetBool("IsMoving", true);

            Quaternion toRotation = Quaternion.LookRotation(_movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }

        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
