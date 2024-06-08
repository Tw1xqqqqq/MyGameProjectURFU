using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    private PlayerInput _input;
    private IShootable _shootable;
    private CharacterStateMachine _stateMachine;
    private Player _player;
    public PlayerInput Input => _input;
    private void Awake()
    {
        _player = GetComponent<Player>();
        _stateMachine = new CharacterStateMachine(_player);
        _shootable = GetComponent<IShootable>();
        _input = new PlayerInput();
        _input.Enable();
    }
    private void OnEnable()
    {
        _input.Movement.Shooting.performed += ShootOnPerformed;
    }
    private void OnDisable()
    {
        _input.Movement.Shooting.performed -= ShootOnPerformed;
    }
    
    private void ShootOnPerformed(InputAction.CallbackContext obj)
    {
        //_shootable.Shoot();
    }
}
