using System.Collections;
using UnityEngine;


public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    // stats atuais (current)
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentMaxHealth;
    [HideInInspector] public float currentDamage;

    public float deSpawnDistance = 20f;
    Transform player;

    
    [Header("Damage Feedback")]
    public Color damageColor = new Color(1, 0, 0, 1);
    public float damageFlashDuration = 0.2f;
    public float deathFadeTime = 0.1f;
    Color originalColor;
    SpriteRenderer sr;
    EnemyMovement movement;
    
    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentMaxHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    private void Start()
    {
        player = FindAnyObjectByType<PlayerStats>().transform;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;

        movement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) >= deSpawnDistance)
        {
            ReturnEnemy();
        }
    }

    public void TakeDamage(float dmg,  Vector2 sourcePosition, float knockbackForce = 5f, float knockbackDuration = 0.2f)
    {
        currentMaxHealth -= dmg; // diminui o HP
        StartCoroutine(DamageFlash());

        if (knockbackForce > 0)
        {
            Vector2 dir = (Vector2)transform.position - sourcePosition;
            movement.Knockback(dir.normalized * knockbackForce, knockbackDuration);
        }

        if(currentMaxHealth <= 0)
        {
            Kill(); // cabou o Life ele morre
        }
    }

    IEnumerator DamageFlash()
    {
        sr.color = damageColor;
        yield return new WaitForSeconds(damageFlashDuration);
        sr.color = originalColor;
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

    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnKilledEnemy();
    }

    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPositions[Random.Range(0, es.relativeSpawnPositions.Count)].position;
    }
}
