using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPossessBehaviour : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPossess PPossess = animator.gameObject.GetComponent<PlayerPossess>();
        PPossess.Possess();
    }
}
