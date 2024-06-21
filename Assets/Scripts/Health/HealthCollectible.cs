using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private Health playerHealth;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerHealth.AddHealth(healthValue);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
