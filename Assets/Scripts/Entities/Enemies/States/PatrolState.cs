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
        //Inicio animacion caminar
    }
    public override void Do()
    {

    }
    public override void FixedDo()
    {
        if (body.gameObject.transform.position != waypoints[currentWaypoint].position)
        {
            body.gameObject.transform.position = Vector2.MoveTowards(body.gameObject.transform.position, waypoints[currentWaypoint].position, input.movementSpeed.magnitude * Time.fixedDeltaTime);
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
        print("Inicio espera");
        yield return new WaitForSecondsRealtime(waitTime);
        //Inicio animacion reposo
        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        print("FIn espera");
        isWaiting = false;
        Enter();
    }
}
