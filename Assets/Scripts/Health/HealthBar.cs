using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealhtBar;
    [SerializeField] private Image currentHealthBar;

    private void Start (){
        totalHealhtBar.fillAmount = playerHealth.currentHealth / 10;
    }

    private void Update (){
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}