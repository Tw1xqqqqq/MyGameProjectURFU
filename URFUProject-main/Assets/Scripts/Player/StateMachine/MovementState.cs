using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly MovementData Data;
    
    
    private readonly Player _player;


    public MovementState(IStateSwitcher stateSwitcher, MovementData data, Player player)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _player = player;
    }

    protected PlayerInput Input => _player.Input;
    protected CharacterController _characterController => _player.CharacterController;

    protected PlayerAnim PlayerAnim => _player.PlayerAnim;
    
    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void HandleInput()
    {
        Data.Direction = ReadDirection();
    }

    public virtual void Update()
    {
       PlayerMove();
    }
    
    protected bool IsHorizontalInputZero() => Data.Direction == new Vector3(0f,0f,0f);

    private void PlayerMove()
    {
        Vector3 velocity = GetConvertedVelocity();
        _characterController.Move(velocity * Data.Speed * Time.deltaTime);
    }

    private Vector3 GetConvertedVelocity() => new Vector3(Data.Direction.x, 0, Data.Direction.z);

    private Vector3 ReadDirection() => Input.Movement.Move.ReadValue<Vector3>();
}