using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : PlayerState
{
    public PlayerWallJump(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(-player.facingDir * 5, player.jumpForce);
        stateTimer = 1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.ChangeState(player.airState);
        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
