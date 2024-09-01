using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 0.5f;

    private bool isWaiting = false;

    public int currentWaypoint = 0;
    public override void Enter()
    {
        animator.Play("Walk");
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        if (body.gameObject.transform.position != waypoints[currentWaypoint].position)
        {
            Vector2 waypointDirection = new Vector2(waypoints[currentWaypoint].position.x, waypoints[currentWaypoint].position.y);
            SpriteRenderer mainSpriteRenderer = body.gameObject.GetComponent<BaseMovementEntitiesController>().spriteRenderer;
            body.gameObject.transform.position = Vector2.MoveTowards(body.gameObject.transform.position, waypoints[currentWaypoint].position, input.movementSpeed.magnitude * Time.fixedDeltaTime);
            if (waypointDirection.x - body.gameObject.transform.position.x > 0) 
            {
                mainSpriteRenderer.flipX = false;
            }
            else
            {
                mainSpriteRenderer.flipX = true;
            }
        }
        else if (!isWaiting)
        {
            isWaiting = true;
            StartCoroutine("IdleTime");
        }

    }
    public override void Exit()
    {
        StopCoroutine("IdleTime");
        isWaiting = false;
    }
    IEnumerator IdleTime()
    {
        animator.Play("Idle");
        yield return new WaitForSecondsRealtime(waitTime);
        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
        Enter();
    }
}
