using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateIdleBattery : State<MonsterFSM>
{
    private Animator animator;
    private BoxCollider boxController;

    //protected int hashMove = Animator.StringToHash("Move");
    //protected int hashMoveSpd = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        boxController = stateMachineClass.GetComponent<BoxCollider>();
    }

    public override void OnStart()
    {
        // animator?.SetBool(hashMove, false); 
        //animator.SetFloat(hashMoveSpd, 0); 

    }

    public override void OnUpdate(float deltaTime)
    {
        if (stateMachineClass.target)
        {
            Debug.Log(stateMachineClass.getFlagAtk);
            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<stateAtkBattery>();
            }
          
        }
    }

    public override void OnEnd()
    {
    }
}
