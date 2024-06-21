using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; set; }
    private bool dead;
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth <= 0 && !dead)
        {
            GetComponent<MushroomMovement>().enabled = false;
            dead = true;
            anim.SetTrigger("death"); // Trigger the death animation
            StartCoroutine(DestroyAfterAnimation()); // Wait for animation to complete before destroying
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Assuming the death animation is named "Death" and its length is 1 second
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
