using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private float moveDir=1;
    private Transform player;
    private Enemy_Skeleton enemy;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                enemy.SetZeroVelocity();
                stateMachine.ChangeState(enemy.attackState);
                return;
            }
        }

        if (player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else if(player.position.x < enemy.transform.position.x)
            moveDir = -1;
        enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.rb.velocity.y);
    }
}
