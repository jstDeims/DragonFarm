using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    [SerializeField] private Transform playerPosition;

    public override void Enter()
    {
        //Inicio animacion caminar
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        var playerDirection = new Vector2(playerPosition.position.x, playerPosition.position.y);
        if (body.position != playerDirection)
        {
            var direction = playerDirection - body.position;
            direction.Normalize();
            body.MovePosition(body.position + (direction * input.movementSpeed * Time.fixedDeltaTime));
        }
    }
    public override void Exit()
    {

    }
}
