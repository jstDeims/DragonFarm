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
                body.gameObject.transform.position = Vector2.MoveTowards(body.gameObject.transform.position, playerPosition.position, input.movementSpeed.magnitude * Time.fixedDeltaTime);
        }
    }
    public override void Exit()
    {

    }
}
