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
        currentHealth = playerMaxHealth;
        maxHealth.fillAmount = 1f; 
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

    private void Die()
    {
        Debug.Log("Dead");
    }
}
