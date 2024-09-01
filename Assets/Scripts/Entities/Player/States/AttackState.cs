using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private float attackRatio = 2;
    [SerializeField] private int damageAmount = 1;


    public override void Enter()
    {
        animator.Play("Attack");
        GameObject lastGameObject = this.gameObject;
        Collider2D[] objects = Physics2D.OverlapCircleAll(body.position, attackRatio);
        foreach (Collider2D obj in objects)
        {
            if (obj.CompareTag("Enemy") && body.gameObject.tag == "Player") 
            {
                obj.gameObject.GetComponent<EnemyMovementController>().healthController.TakeDamage(damageAmount);
            }
            else if (obj.CompareTag("Player") && body.gameObject.tag == "Enemy")
            {
                obj.gameObject.GetComponent<PlayerController>().healthController.TakeDamage(damageAmount);
            }
            lastGameObject = obj.gameObject;
        }
    }
    public override void Do()
    { 

    }
    public override void FixedDo()
    {

    }
    public override void Exit()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRatio);
    }
}