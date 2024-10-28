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
    [SerializeField] Vector3 _myGrav = new Vector3(0, -9.81f, 0);
    [SerializeField] Vector3 _currGrav = new Vector3(0, -9.81f, 0);
    [SerializeField] float _gravMultip;
    [SerializeField] float _gravForce;

    MyInputManager _inpt;
    bool _inWalkFwrd;
    bool _inWalkBck;
    bool _inRotateLeft;
    bool _inRotateRght;
    bool _inAttack;
    bool _inRoll;
    bool _inJump;
    [SerializeField] bool _isGrounded;
    bool _isGliding;
    float _jumpCooldown;
    [SerializeField]float _jumpCooldownTimeSetter;

    public void SetGrounded(bool value)
    {
        _jumpCooldown = _jumpCooldownTimeSetter;
        _isGrounded = value;
    }

    void Start()
    {
        _inpt = FindAnyObjectByType<MyInputManager>();
        _rb.useGravity = false;
        //_myGrav.y *= _gravMultip;
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

        if (_jumpCooldown >= 0)
        {
            _jumpCooldown -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        var _jumped = false;
        if (_inJump && _isGrounded && _jumpCooldown < 0)
        {
            _jumped = true;
        }
        else if (_inJump && !_isGrounded) {
            _isGliding = true;
        } else
        {
            _isGliding = false;
        }
        if (_jumped) {
            _jumpCooldown = _jumpCooldownTimeSetter;
            _isGrounded = false;
            _rb.AddForce(new Vector3(0f, _jumpStrenght), ForceMode.Impulse);
        }

        if (_isGliding)
        {
            _gravForce = 0.5f;
        } else
        {
            _gravForce = 1;
        }
        // Calcular Gravedad Actual
        _currGrav = _myGrav * _gravForce * _gravMultip;

        // Movimiento hacia adelante y hacia atrás
        var _myDirZ = 0f;
        if (_inWalkFwrd)
        {
            _myDirZ = 1f;
        }
        else if (_inWalkBck)
        {
            _myDirZ = -1f;
        }

        // Crear el vector de movimiento en el eje Z local
        Vector3 mov = new Vector3(0f, 0f, _myDirZ);

        // Obtener la velocidad actual del Rigidbody
        Vector3 velocity = _rb.velocity;

        // Aquí multiplicas la dirección de movimiento por la rotación del objeto (para moverse en la dirección local)
        velocity = transform.TransformDirection(mov) * _curSpeed;

        // Actualizar la velocidad del Rigidbody
        _rb.velocity = new Vector3(velocity.x, _rb.velocity.y, velocity.z); // Mantenemos la velocidad en Y (gravedad)

        // Rotación del objeto
        var _myRot = 0f;
        if (_inRotateRght)
        {
            _myRot = 1f;
        }
        else if (_inRotateLeft)
        {
            _myRot = -1f;
        }

        // Obtener la rotación actual del objeto
        Quaternion currentRotation = transform.rotation;

        // Incrementar la rotación en el eje Y
        Quaternion targetRotation = Quaternion.Euler(0f, _myRot * _rotSpeed * Time.deltaTime, 0f);

        // Aplicar la rotación al Rigidbody
        _rb.MoveRotation(currentRotation * targetRotation);

        _rb.AddForce(_currGrav, ForceMode.Acceleration);
    }
}
