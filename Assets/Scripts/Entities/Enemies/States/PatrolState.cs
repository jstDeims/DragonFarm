using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 0.5f;

    private bool isWaiting = false;

    private int currentWaypoint = 0;
    public override void Enter()
    {
        //Inicio animacion caminar
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        Vector2 nextWaypointPosition = new Vector2(waypoints[currentWaypoint].position.x, waypoints[currentWaypoint].position.y);
        Vector2 direction = nextWaypointPosition - body.position;
        print(direction);
        if (direction.magnitude < 0.3f)
        {
            direction.Normalize();
            body.MovePosition(body.position + (direction * input.movementSpeed * Time.fixedDeltaTime));
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
        yield return new WaitForSecondsRealtime(waitTime);
        //Inicio animacion reposo
        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
        Enter();
    }
}
