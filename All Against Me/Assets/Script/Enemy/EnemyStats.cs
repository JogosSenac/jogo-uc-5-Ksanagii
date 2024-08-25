using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    // stats atuais (current)
    protected float currentMoveSpeed;
    protected float currentMaxHealth;
    protected float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentMaxHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }
    public void TakeDamage(float dmg)
    {
        currentMaxHealth -= dmg; // diminui o HP
        if(currentMaxHealth <= 0)
        {
            Kill(); // cabou o Life ele morre
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
