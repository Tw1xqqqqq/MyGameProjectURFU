using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunningState : MovementState
{
    public RunningState(IStateSwitcher stateSwitcher, MovementData data, Player player) : base(stateSwitcher, data, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerAnim.StartWalk();
        Data.Speed = 5;
    }

    public override void Exit()
    {
        base.Exit();
        PlayerAnim.StopWalk();
    }

    public override void Update()
    {
        base.Update();
        
        if(IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }
}
