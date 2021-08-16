using System.Collections;
using System;
using UnityEngine;
using PlayerControlls;
public class PlayerSprintSystem : MonoBehaviour
{
    private static PlayerSprintSystem m_instance;
    public static PlayerSprintSystem Instance => m_instance;

    [SerializeField] ItemUpgrade upgrade;
    [SerializeField] float maxEnergy;
    [SerializeField] float currentEnergy;
    [SerializeField] float energyDrainMultiplier;
    [SerializeField] float energyGainMultipier;

    FirstPersonController player;
    public bool canTakeEnergy;
    
    public float NormalisedEnergy => currentEnergy / maxEnergy;

    public event Action<float> OnPlayerSprintChange;

    public float CurrentEnergy => currentEnergy;
    public float MaxEnergy => maxEnergy;
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        player = this.GetComponent<FirstPersonController>();
        SprintObject.OnPlayerConsumeSprint += ConsumeEnergy;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxEnergy = upgrade.CurrentPower;
        currentEnergy = maxEnergy;
        OnPlayerSprintChange?.Invoke(NormalisedEnergy);
        canTakeEnergy = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ApplySprintEnergy();
        TakeEnergy();
    }
    void ApplySprintEnergy()
    {
        if (canTakeEnergy)
        {
            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                canTakeEnergy = true;
                PlayerMovement_InputData.Instance.IsRunning = false;
                return;
            }
            currentEnergy -= Time.deltaTime * energyDrainMultiplier;
            OnPlayerSprintChange?.Invoke(NormalisedEnergy);
        }
    }
    void TakeEnergy()
    {
        if (!canTakeEnergy)
        {
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
                canTakeEnergy = false;
                return;
            }
            currentEnergy += Time.deltaTime * energyGainMultipier;
            OnPlayerSprintChange?.Invoke(NormalisedEnergy);

        }

    }

    void ConsumeEnergy(float amount)
    {
        currentEnergy = amount;
        OnPlayerSprintChange.Invoke(NormalisedEnergy);
    }

    public float MinEnergyToRun()
    {
        return (10 / 100) * maxEnergy;
    }
    private void OnDestroy()
    {
        SprintObject.OnPlayerConsumeSprint -= ConsumeEnergy;
    }
}
