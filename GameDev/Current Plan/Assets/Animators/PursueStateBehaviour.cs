using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueStateBehaviour : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemyai enemyai = animator.gameObject.GetComponentInParent<Enemyai>();
        enemyai.StartPursuit();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemyai enemyai = animator.gameObject.GetComponentInParent<Enemyai>();
        enemyai.StopPursuit();
    }

}
