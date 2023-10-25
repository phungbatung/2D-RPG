using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Stunned info")]
    public float stunnedDuration;
    public Vector2 stunnedDirection;

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttacked;

    [SerializeField] protected LayerMask whatIsPlayer;
    public EnemyStateMachine stateMachine { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }
    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(transform.position, Vector2.right * facingDir, 50, whatIsPlayer);
}
