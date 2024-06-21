using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaMushroom : MonoBehaviour
{
   [SerializeField] private Health playerHealth;
    private float damage = 1;
  

     private void Awake(){
        if (playerHealth == null)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }else{
            Debug.LogError("Player not found");
        
        }
    }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Deactivate the bomb on collision
        gameObject.SetActive(false);
        
        // Destroy the bomb after it deactivates
        Destroy(gameObject);
    }

    // Optionally, handle trigger collisions if needed
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(damage);
            playerHealth.TakeDamage(damage);
        }
        // Deactivate the bomb on trigger collision
        gameObject.SetActive(false);

        // Destroy the bomb after it deactivates
        Destroy(gameObject);
    }


}
