using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerBaseState(StateMachine stateMachine) : base(stateMachine)
    {
        this.stateMachine = stateMachine;   
    }

    protected void Move(float deltaTime)
    {
        //Move(Vector3.zero, deltaTime);
    }

    //protected void ReturnToLocomotion()
    //{
    //    if (stateMachine.Targeter.CurrentTarget != null)
    //    {
    //        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    //    }
    //    else
    //    {
    //        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    //    }
    //}
}

