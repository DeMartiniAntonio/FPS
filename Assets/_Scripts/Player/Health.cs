using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int playerMaxHealth = 100; 
    [SerializeField] private int currentHealth;
    [SerializeField] private Image maxHealth;

    private void Start()
    {
        currentHealth = playerMaxHealth-50;
        maxHealth.fillAmount = (float)currentHealth / playerMaxHealth;  
    }


    internal void TakeDamage(int damaga)
    {
        currentHealth -= damaga;
        maxHealth.fillAmount = (float)currentHealth / playerMaxHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    internal void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > playerMaxHealth)
        {
            currentHealth = playerMaxHealth;
        }
        maxHealth.fillAmount = (float)currentHealth / playerMaxHealth;
    }

    private void Die()
    {
        Debug.Log("Dead");
    }
}
