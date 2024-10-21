using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody _rb;

    [Header("Stadistics")]
    [SerializeField] float _walkSpeed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _jumpStrenght;
    [SerializeField] float _gravityScale;
    float _curSpeed;
    [SerializeField] float _rotSpeed; // Rotation Speed

    MyInputManager _inpt;
    bool _inWalkFwrd;
    bool _inWalkBck;
    bool _inRotateLeft;
    bool _inRotateRght;
    bool _inAttack;
    bool _inRoll;
    bool _inJump;

    void Start()
    {
        _inpt = FindAnyObjectByType<MyInputManager>();
    }
    void Update()
    {
        _inWalkFwrd = _inpt.GetMoveUp;
        _inWalkBck = _inpt.GetMoveDown;
        _inRotateLeft = _inpt.GetMoveLeft;
        _inRotateRght = _inpt.GetMoveRight;
        _inAttack = _inpt.GetAbility1;
        _inRoll = _inpt.GetAbility2;
        _inJump = _inpt.GetJump;

        _curSpeed = _walkSpeed;

    }

    private void FixedUpdate()
    {
        var _myDirZ = 0f;
        if (_inWalkFwrd)
        {
            _myDirZ = 1f;
        }
        else if (_inWalkBck)
        {
            _myDirZ = -1f;
        }
        Vector3 mov = new Vector3(0f, 0f, _myDirZ);
        Vector3 velocity = _rb.velocity;
        velocity.z = mov.z * _curSpeed;
        _rb.velocity = velocity;

        var _myRot = 0f;
        if (_inRotateRght)
        {
            print("Presiono Der");
            _myRot = 1f;
        }
        else if (_inRotateLeft)
        {
            print("Presiono Izq");
            _myRot = -1f;
        }
        //Quaternion rot = new Quaternion(0f, _myRot, 0f, 0f);
        Quaternion rot = Quaternion.Euler(0f, _myRot, 0f);
        Quaternion rotation = _rb.rotation;
        rotation.y = rot.y * _rotSpeed;
        _rb.rotation = rotation;

    }
}
