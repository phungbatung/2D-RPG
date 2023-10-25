using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();
    public void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    public void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackPoint.position, player.attackRadius);
        foreach (Collider2D hit in colliders)
        {
            if(hit.GetComponent<Enemy>()!=null)
            {
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }
}
