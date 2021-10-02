using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaserStateDefinition : StateMachineBehaviour
{
    static int Hints = 0;

    public void GoodCorridor(int depth = 1)
    {
        LevelManager.Instance.Generate(Rooms.Get("Empty"), null, Random.Range(5, 9));
        Hints += LevelManager.Instance.Generate(Rooms.Get("Corridors"), null, depth);
        LevelManager.Instance.Generate(Rooms.Get("Empty"), null, Random.Range(5, 9));
        LevelManager.Instance.Generate(Rooms.Get("Openings"), null, 1);
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Hints += LevelManager.Instance.Generate(Rooms.Get("Start"), null, 3);
        GoodCorridor(6);
        Hints += LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        GoodCorridor(3);
        GoodCorridor(4);
        Hints += LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        GoodCorridor(3);
        Hints += LevelManager.Instance.Generate(Rooms.Get("Big Rooms"), null, 1);
        GoodCorridor(5);
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
