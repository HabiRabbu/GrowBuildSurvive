using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

    public event EventHandler OnHealthAmountMaxChanged;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDied;

    [SerializeField] private int healthAmountMax;
    private int healthAmount;

    private void Awake() {
        healthAmount = healthAmountMax;
    }

    public void Damage(int damageAmount) {
        healthAmount -= damageAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnDamaged?.Invoke(this, EventArgs.Empty);

        if (IsDead()) {
            OnDied?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount) {
        healthAmount += healAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, healthAmountMax);

        OnHealed?.Invoke(this, EventArgs.Empty);
    }

    public void HealFull() {
        healthAmount = healthAmountMax;

        OnHealed?.Invoke(this, EventArgs.Empty);
    }

    public bool IsDead() {
        return healthAmount == 0;
    }

    public bool IsFullHealth() {
        return healthAmount == healthAmountMax;
    }

    public int GetHealthAmount() {
        return healthAmount;
    }

    public int GetHealthAmountMax() {
        return healthAmountMax;
    }

    public float GetHealthAmountNormalized() {
        return (float)healthAmount / healthAmountMax;
    }

    public void SetHealthAmountMax(int healthAmountMax, bool updateHealthAmount) {
        this.healthAmountMax = healthAmountMax;

        if (updateHealthAmount) {
            healthAmount = healthAmountMax;
        }

        OnHealthAmountMaxChanged?.Invoke(this, EventArgs.Empty);
    }

}
