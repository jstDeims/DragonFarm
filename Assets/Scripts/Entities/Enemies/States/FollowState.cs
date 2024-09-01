using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{
    [SerializeField] private Transform playerPosition;

    public override void Enter()
    {
        animator.Play("Walk");
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        Vector2 playerDirection = new Vector2(playerPosition.position.x, playerPosition.position.y);
        SpriteRenderer mainSpriteRenderer = body.gameObject.GetComponent<BaseMovementEntitiesController>().spriteRenderer;
        body.gameObject.transform.position = Vector2.MoveTowards(body.gameObject.transform.position, playerPosition.position, input.movementSpeed.magnitude * Time.fixedDeltaTime);
        if (playerDirection.x - body.gameObject.transform.position.x > 0)
        {
            mainSpriteRenderer.flipX = false;
        }
        else
        {
            mainSpriteRenderer.flipX = true;
        }
    }
    public override void Exit()
    {

    }
}
