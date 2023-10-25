using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public EntityFX fx {  get; private set; }
    #endregion

    [Header("Collisions info")]
    [SerializeField] public Transform attackPoint;
    [SerializeField] public float attackRadius;
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;

    [Header("KnockBack info")]
    [SerializeField] protected Vector2 knockDirection;
    protected bool isKnock;
    [SerializeField] protected float knockbackDuration;
    public int facingDir { get; private set; } = 1;
    protected bool facingRight = true;
    protected virtual void Awake()
    {
        
    }
    protected virtual void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<EntityFX>();
    }

    protected virtual void Update()
    {
        
    }
    public void Damage()
    {
        fx.StartCoroutine("FlashFX");
        StartCoroutine("HitKnockback");
        Debug.Log(gameObject.name + " is damage");
    }
    protected IEnumerator HitKnockback()
    {
        isKnock = true;
        rb.velocity = new Vector2(knockDirection.x * facingDir * -1, knockDirection.y);
        yield return new WaitForSeconds(knockbackDuration);
        isKnock = false;
    }
    #region Velocity
    public virtual void SetZeroVelocity()
    {
        if (isKnock) return;
        rb.velocity = new Vector2(0, 0);
    }
    public virtual void SetVelocity(float _xVelocity, float _yVelocity)
    {
        if (isKnock) return;
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    
    #endregion
    #region Flip
    public virtual void Flip()
    {
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public virtual void FlipController(float _x)
    {
        if (_x > 0 && !facingRight)
            Flip();
        else if (_x < 0 && facingRight)
            Flip();
    }
    #endregion
    #region Collisions
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance*facingDir, whatIsGround);
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance*facingDir, wallCheck.position.y));
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
    #endregion
}
