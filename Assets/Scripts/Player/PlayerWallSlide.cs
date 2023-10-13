using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlide : PlayerState
{
    public PlayerWallSlide(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space)) 
        { 
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }
        if(!player.IsWallDetected())
        {
            stateMachine.ChangeState(player.airState);
            return;
        }    
        if (yInput < 0)
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .7f);

        if (xInput!=0 && xInput != player.facingDir || player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
