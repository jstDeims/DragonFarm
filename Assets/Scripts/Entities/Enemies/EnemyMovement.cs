using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : BaseMovementEntitiesController
{
    [Header("controladores")]
    public HealthController healthController;
    [Header("Estados")]
    [SerializeField] private PatrolState patrolState;
    [SerializeField] private FollowState followState;
    [SerializeField] private AttackState attackState;
    State state;
    [Header("Caracteristicas jugador")]
    [SerializeField] Transform player_position;
    [SerializeField] float distanceToAttack = 1f;

    private Rigidbody2D body;
    private Animator animator;
    private bool oncePlayerTrigger = false;
    private bool attaking = false;
    void Start()
    {
        //Componentes
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Asignacion componentes estados
        patrolState.Setup(body, animator, this);
        followState.Setup(body, animator, this);
        attackState.Setup(body, animator, this);
        state = patrolState;
    }

    void Update()
    {
        HandleAttack();
        state.Do();
    }

    void FixedUpdate()
    {
        state.FixedDo();
    }
    void HandleAttack()
    {
        Vector3 distanceToPlayer = player_position.position - transform.position;
        float distance = distanceToPlayer.magnitude;
        if (distance <= distanceToAttack && !attaking)
        {
            state = attackState;
            StartCoroutine("AttackTime");
            attaking = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (oncePlayerTrigger)
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            state = followState;
            oncePlayerTrigger = true;
        }
    }
    IEnumerator AttackTime()
    {
        state.Enter();
        yield return new WaitForSecondsRealtime(attackTime);
        state = followState;
        attaking = false;
    }
}
