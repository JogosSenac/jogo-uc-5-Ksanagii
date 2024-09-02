using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    // stats atuais (current)
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentMaxHealth;
    [HideInInspector] public float currentDamage;

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

    // se colar no inimigo
    void OnTriggerStay2D(Collider2D col)
    {
        // verifica se e o player, pega o metodo do player levar dano e aplica o dano
        if(col.CompareTag("Player"))
        {
            PlayerStats plStats = col.gameObject.GetComponent<PlayerStats>();
            plStats.TakeDamage(currentDamage);
        }
    }
}
