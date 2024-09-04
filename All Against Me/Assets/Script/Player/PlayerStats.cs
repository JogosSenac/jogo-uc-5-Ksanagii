using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public CharacterScriptableObject characterData;

    public float currentHealth;
    [HideInInspector] public float currentRecovery;
    [HideInInspector] public float currentMight;
    [HideInInspector] public float currentMoveSpeed;
    [HideInInspector] public float currentProjectileSpeed;
    [HideInInspector] public float currentMagnet;

    public bool isDead;

    // experience

    [Header("Experience/Level")]
    public int level = 1;
    public int experience = 0;
    public int experienceCap = 100;
    public int experienceCapIncrease;

    [Header("Taking Damage Frames")]
    public float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    [Header("UI")]
    public Image healthBar;
    public TextMeshProUGUI levelText;
    public GameObject gameOverUI;

    void Awake()
    {

        isDead = false;
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMight = characterData.Might;
        currentMoveSpeed = characterData.MoveSpeed;
        currentProjectileSpeed = characterData.ProjectileSpeed;
        currentMagnet = characterData.Magnet;
    }

    void Start()
    {
        UpdateHealthBar();
        UpdateLevelBar();
    }
    void Update()
    {
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.timeScale;
        }
        else if(isInvincible)
        {

            isInvincible = false;
        }

        RecoveryHealth();
    }

    public void IncreaseExp(int amount) // metodo para acrescentar vida e logo depois verifica se ja pode evoluir
    {
        experience += amount;

        LevelUpdate();
    }

    void LevelUpdate()
    {
        if(experience > experienceCap)
        {
            experience -= experienceCap; // zera as experiencia obtida do level e mantem as que passaram
            level++; 
            experienceCap += experienceCapIncrease; // capacidade aumenta

            // a cada 10 levels duplica o tanto de xp que acrescenta a capacidade normal normal
            if (level > 10) 
            {
                experienceCap += experienceCapIncrease;
            }
            if (level > 20)
            {
                experienceCap += experienceCapIncrease;
            }
            if (level > 30)
            {
                experienceCap += experienceCapIncrease;
            }
            if (level > 40)
            {
                experienceCap += experienceCapIncrease;
            }
            UpdateLevelBar();
        }
    }

    public void TakeDamage(float dmg) // metodo para chamar e dar dano ao player
    {
        if(!isInvincible && invincibilityTimer <= 0) // invencibilidade
        {
            currentHealth -= dmg;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                Kill();
            }
        }
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / characterData.MaxHealth;
    }

    void UpdateLevelBar()
    {
        levelText.text = "Lv. " + level;
    }

    public void Kill()
    {
        isDead = false;
        Debug.Log("Ta mortinho da silva");
        gameOverUI.SetActive(true);

        Destroy(gameObject);
    }

    void RecoveryHealth()
    {
        // se estiver com menos de vida que o maximo, recupera ela
        if(currentHealth < characterData.MaxHealth)
        {
            currentHealth += currentRecovery * Time.deltaTime;
        }

        // se passar do maximo de life, retorna ao normal
        if(currentHealth > characterData.MaxHealth)
        {
            currentHealth = characterData.MaxHealth;
        }

    }
}
