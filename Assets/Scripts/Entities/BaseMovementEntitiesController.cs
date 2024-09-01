using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseMovementEntitiesController : MonoBehaviour
{
    [Header("Caracteristicas movimiento")]
    public Vector2 movementSpeed = new Vector2(1.0f, 1.0f);
    [SerializeField] protected float attackTime = 0.2f;
    public SpriteRenderer spriteRenderer;
    public Vector2 inputVector { get; protected set; } = new Vector2(0.0f, 0.0f);
    protected virtual void HandleMovement()
    {
    }
    protected virtual void HandleAttack()
    {
    }
}
