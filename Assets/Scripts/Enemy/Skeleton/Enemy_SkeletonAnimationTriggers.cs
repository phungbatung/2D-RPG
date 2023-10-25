using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonAnimationTriggers : MonoBehaviour
{
    Enemy_Skeleton enemy => GetComponentInParent<Enemy_Skeleton>();
    
    public void AnimationTrigger() => enemy.AnimationTrigger();
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackPoint.position, enemy.attackRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().Damage();
            }
        }
    }
}
