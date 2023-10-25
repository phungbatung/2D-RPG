using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private Enemy_Skeleton enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.stunnedDuration;
        enemy.rb.velocity = new Vector2(-enemy.facingDir * enemy.stunnedDirection.x, enemy.stunnedDirection.y);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.fx.Invoke("CancelRedBlink", 0);
    }

    public override void Update()
    {
        base.Update();
        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);
        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
