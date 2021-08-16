using System;
using UnityEngine;
using PlayerControlls;
public class PlayerHealthSystem : MonoBehaviour
{
    private static PlayerHealthSystem m_instance;
    public static PlayerHealthSystem Instance => m_instance;

    [SerializeField] float playerMaxHealth;
    [SerializeField] float damageRate;
    [SerializeField] float playerCurrentHealth;
    [SerializeField] ItemUpgrade upgrade;
    [SerializeField] float damageHealStartTime;
    public event Action<float, float> OnPlayerHealthChange;
    public event Action OnPlayerDead;

    float lastDamageTakenTime;
    float damageElapsedTime;
    [SerializeField] float healMultiplier;

    public float PlayerCurrentHealth => playerCurrentHealth;
    public float PlayerMaxHealth => playerMaxHealth;

    private void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        PlayerDamageByMelee.OnSwordHit += TakeDamage;
        PlayerDamageByShoot.OnProjectileHit += TakeDamage;
        HealthObject.OnPlayerConsumeHealth += ConsumeHealth;
        playerMaxHealth = upgrade.CurrentPower;
    }
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        OnPlayerHealthChange?.Invoke(playerCurrentHealth, playerMaxHealth);
    }

    private void LateUpdate()
    {
        if (playerCurrentHealth.Equals(playerMaxHealth)) return;
        damageElapsedTime = Time.time - lastDamageTakenTime;
        if(damageElapsedTime >= damageHealStartTime && playerCurrentHealth < playerMaxHealth && !PlayerMovement_InputData.Instance.HasInput)
        {
            Heal();
        }
    }
    void TakeDamage(float amount)
    {
        playerCurrentHealth -= amount;
        OnPlayerHealthChange.Invoke(playerCurrentHealth, playerMaxHealth);
        lastDamageTakenTime = Time.time;
        if(playerCurrentHealth <= 0)
        {
            OnPlayerDead?.Invoke();
        }
    }

    void ConsumeHealth(float amount)
    {
        playerCurrentHealth = amount;
        OnPlayerHealthChange.Invoke(playerCurrentHealth, playerMaxHealth);
    }

    void Heal()
    {
        playerCurrentHealth += Time.deltaTime * healMultiplier;
        OnPlayerHealthChange?.Invoke(playerCurrentHealth, playerMaxHealth);
        if (playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
            lastDamageTakenTime = 0;
            return;
        }
    }

    private void OnDestroy()
    {
        PlayerDamageByMelee.OnSwordHit -= TakeDamage;
        PlayerDamageByShoot.OnProjectileHit -= TakeDamage;
        HealthObject.OnPlayerConsumeHealth -= ConsumeHealth;
    }
}
