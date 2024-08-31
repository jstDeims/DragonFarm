using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override void Enter()
    {

        isComplete = true;
    }
    public override void Do()
    {
        
    }
    public override void FixedDo()
    {
        body.MovePosition(body.position + (input.inputVector * input.movementSpeed * Time.fixedDeltaTime));
    }
    public override void Exit()
    {
        
    }
}
