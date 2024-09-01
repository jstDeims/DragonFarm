using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    public bool death { get; private set; } = false;
    private int actLife;

    private void Start()
    {
        actLife = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        actLife -= damage;
        if (actLife < 0) 
        {
            actLife = 0;
            death = true;
            return;
        }

    }
    public void Heal(int healAmount)
    {
        if (death) {return;}
        actLife += healAmount;
        if (actLife > maxHealth) { actLife = maxHealth;}
    }
}
