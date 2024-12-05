using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PYR_Animation : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] MyInputManager _inpt;
    [SerializeField] PlayerManager _pMan;
    bool _inWalkFwrd;
    bool _inWalkBck;
    bool _inWalkLeft;
    bool _inWalkRght;
    bool _inAttack;
    bool _inJump;

    bool _isGrounded;

    float _groundedDelay;
    Vector3 _moveSpeed;
    float _translationValue;

    void Start()
    {
        
    }

    void Update()
    {
        _inWalkFwrd = _inpt.GetMoveUp;
        _inWalkBck = _inpt.GetMoveDown;
        _inWalkLeft = _inpt.GetMoveLeft;
        _inWalkRght = _inpt.GetMoveRight;
        _inAttack = _inpt.GetAbility1;
        _inJump = _inpt.GetJump;
        _isGrounded = _pMan.GetGrounded;
        _moveSpeed = _pMan.GetCurSpeed;

        if (_inWalkFwrd == true || _inWalkBck == true 
            || _inWalkLeft == true || _inWalkRght == true)
        {
            _animator.SetBool("IsMoving", true);
        } else  
        {
            _animator.SetBool("IsMoving", false);
        }

        if (_inAttack == true)
        {
            _animator.SetBool("IsAttacking", true);
        }

        if (_isGrounded == true)
        {
            _groundedDelay = 0.2f;
            _animator.SetBool("IsGrounded", true);
            _animator.SetBool("IsFalling", false);
        } else if (_isGrounded == false && _groundedDelay <= 0)
        {
            _animator.SetBool("IsGrounded", false);
            _animator.SetBool("IsFalling", true);
        }

        if (_groundedDelay > 0)
        {
            _groundedDelay -= Time.deltaTime;
        }

        if (_inJump == true)
        {
            _animator.SetBool("IsJumping", true);
        } else
        {
            _animator.SetBool("IsJumping", false);
        }

        //_translationValue = Mathf.Abs(_moveSpeed.x) + Mathf.Abs(_moveSpeed.z);
        _translationValue = Mathf.Sqrt(_moveSpeed.x * _moveSpeed.x + _moveSpeed.z * _moveSpeed.z);
        _animator.SetFloat("Input Magnitude", _translationValue / 25);
        print("Movimiento en X" + _translationValue);
    }
}
