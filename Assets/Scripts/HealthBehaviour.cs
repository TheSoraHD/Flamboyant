using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    public UnityEvent OnDie;
    public UnityEvent OnUpdateHealth;
    public float currentHealth, maxHealth;

    private void Start()
    {
        FullHeal();
    }

    private void UpdateHealth()
    {
        OnUpdateHealth.Invoke();
    }

    public void Heal(float h)
    {
        currentHealth += h;
        if (currentHealth > maxHealth)
            FullHeal();
        else
            UpdateHealth();
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }

    public void Hurt(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            currentHealth = 0;
            OnDie.Invoke();
        }
    }

    public void IncreaseMaxHealth(float incmaxhealth)
    {
        maxHealth += incmaxhealth;
        UpdateHealth();
    }

}
