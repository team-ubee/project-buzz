using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaserStateDefinition : StateMachineBehaviour
{
    public void GoodCorridor()
    {
        for (int i = 1; i < 3; i++)
        {
            LevelManager.Instance.Generate(Rooms.Get("Corridors"), null, Random.Range(1, 5));
            LevelManager.Instance.Generate(Rooms.Get("Openings"), null, Random.Range(0, 1));
        }
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LevelManager.Instance.Generate(Rooms.Get("Start"), null, 3);
        GoodCorridor();
        LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        GoodCorridor();
        LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        GoodCorridor();
        LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        LevelManager.Instance.Generate(Rooms.Get("Wolf"), null, 1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
