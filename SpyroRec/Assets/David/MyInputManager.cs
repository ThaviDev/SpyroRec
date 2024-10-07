using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputManager : MonoBehaviour
{
    static PlayerInput _input;
    [SerializeField] PlayerInput _inputRef;

    bool _moveUp;
    bool _moveDown;
    bool _moveLeft;
    bool _moveRight;
    bool _ability1;
    bool _ability2;
    bool _jump;
    bool _start;
    private void Awake()
    {
        _input = _inputRef;
    }
    public bool GetMoveUp { get { return _moveUp; } }
    public bool GetMoveDown { get { return _moveDown; } }
    public bool GetMoveLeft { get { return _moveLeft; } }
    public bool GetMoveRight { get { return _moveRight; } }
    public bool GetAbility1 { get { return _ability1; } }
    public bool GetAbility2 { get { return _ability2; } }
    public bool GetJump { get { return _jump; } }
    public bool GetStart { get { return _start; } }

    void Update()
    {
        if (OnMoveUp()) { _moveUp = true; } else { _moveUp = false; }
        if (OnMoveDown()) { _moveDown = true; } else { _moveDown = false; }
        if (OnMoveLeft()) { _moveLeft = true; } else { _moveLeft = false; }
        if (OnMoveRight()) { _moveRight = true; } else { _moveRight = false; }
        if (OnAbility1()) { _ability1 = true; } else { _ability1 = false; }
        if (OnAbility2()) { _ability2 = true; } else { _ability2 = false; }
        if (OnJump()) { _jump = true; } else { _jump = false; }
        if (OnStart()) { _start = true; } else { _start = false; }
    }

    public static bool OnMoveUp() 
    {
        return _input.actions.FindAction("MoveUp").IsPressed();
    }
    public static bool OnMoveDown() 
    {
        return _input.actions.FindAction("MoveDown").IsPressed();
    }
    public static bool OnMoveLeft() 
    {
        return _input.actions.FindAction("MoveLeft").IsPressed();
    }
    public static bool OnMoveRight()
    {
        return _input.actions.FindAction("MoveRight").IsPressed();
    }
    public static bool OnAbility1()
    {
        return _input.actions.FindAction("Ability1").IsPressed();
    }
    public static bool OnAbility2()
    {
        return _input.actions.FindAction("Ability2").IsPressed();
    }
    public static bool OnJump()
    {
        return _input.actions.FindAction("Jump").IsPressed();
    }
    public static bool OnStart()
    {
        return _input.actions.FindAction("Start").IsPressed();
    }
}
