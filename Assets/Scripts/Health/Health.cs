using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; set; }
    private bool dead;

    [SerializeField] private GameOverManager gameOverManager; // Reference to GameOverManager

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth <= 0 && !dead)
        {
            GetComponent<RedHoodMovement>().enabled = false;
            dead = true;
            
            if (gameOverManager != null)
            {
                gameOverManager.GameOver(); // Call the GameOver method
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
