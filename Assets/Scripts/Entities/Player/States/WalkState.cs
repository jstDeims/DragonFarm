using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : State
{
    public override void Enter()
    {
        animator.Play("Walk");
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
