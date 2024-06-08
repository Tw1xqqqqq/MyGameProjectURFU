using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlingState : MovementState
{
    public IdlingState(IStateSwitcher stateSwitcher, MovementData data, Player player) : base(stateSwitcher, data, player)
    {
    }

   
    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;
        StateSwitcher.SwitchState<RunningState>();
    }
}
