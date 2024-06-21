using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Health playerHealth;
    // Start is called before the first frame update
    private float healthBeforeDamage;
    void Start()
    {
        anim = GetComponent<Animator>(); // Initialize the Animator component
        healthBeforeDamage = playerHealth.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Check if either horizontal or vertical input is not equal to 0
        bool isMoving = horizontalInput != 0 || verticalInput != 0;

        anim.SetBool("run", isMoving);
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump"); // Set the "jump" trigger to transition to the jump animation
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("attack"); // Set the "jump" trigger to transition to the jump animation
        }

        if (playerHealth.currentHealth < healthBeforeDamage)
        {
            anim.SetTrigger("hurt");
            healthBeforeDamage = playerHealth.currentHealth;
        }

        

    }

    public void TakeDamage(float _damage)
    {
        playerHealth.TakeDamage(_damage);
        anim.SetTrigger("hurt");        
    }




}
