using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovementEntitiesController
{
    [Header("Estados")]
    [SerializeField] private WalkState walkState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private AttackState attackState;
    State state;
    [Header("Componentes")]
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private Animator animator;

    private bool attaking = false;

    void Start()
    {
        //Asignacion componentes estados
        idleState.Setup(body, animator, this);
        walkState.Setup(body, animator, this);
        attackState.Setup(body, animator, this);
        state = idleState;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        HandleAttack();
        state.Do();
    }

    void FixedUpdate()
    {
        HandleMovement();
        state.FixedDo();
    }
    void HandleMovement()
    {
        if (attaking)
        {
            state = attackState;
        }
        else if (inputVector.magnitude > 0.0f)
        {
            state = walkState;
        }
        else 
        {
            state = idleState;
        }
        state.Enter();
    }
    void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            attaking = true;
            print("inicio ataque");
            StartCoroutine("AttackTime");
        }
    }
    IEnumerator AttackTime()
    {
        yield return new WaitForSecondsRealtime(attackTime);
        attaking = false;
        print("fin ataque");
    }
}
