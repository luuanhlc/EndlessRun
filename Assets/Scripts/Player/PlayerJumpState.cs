using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateManager _ctx, PlayerStateFactory factory) : base(_ctx, factory)
    {
        _isRootState = true;
    }

    public override void EnterState()
    {
    }
    public override void ExitState()
    {
    }
    public override void UpdateState()
    {
    }

    public override void CheckSwitchState()
    {
    }

    public override void InitSubState()
    {
    }

}
