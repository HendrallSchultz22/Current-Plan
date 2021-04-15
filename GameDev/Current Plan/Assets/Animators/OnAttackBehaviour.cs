using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAttackBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemyai enemyai = animator.gameObject.GetComponentInParent<Enemyai>();
        enemyai.HaltAndFire();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemyai enemyai = animator.gameObject.GetComponentInParent<Enemyai>();
        enemyai.EndFiring();
    }
}
