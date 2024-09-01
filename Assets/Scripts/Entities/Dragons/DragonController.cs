using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : BaseMovementEntitiesController
{
    [Header("Estados")]
    [SerializeField] private PatrolState patrolState;
    State state;

    private Rigidbody2D body;
    private Animator animator;
    void Start()
    {
        //Componentes
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Asignacion componentes estados
        patrolState.Setup(body, animator, this);
        state = patrolState;
    }

    void Update()
    {
        state.Do();
    }

    void FixedUpdate()
    {
        state.FixedDo();
    }
}
