using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaShoot : MonoBehaviour
{
    public GameObject bombPrefab; // Bomb prefab to instantiate
    public Transform player; // Reference to the player
    public float detectionRadius = 4f; // Radius to detect the player
    public float bombSpeed = 10f; // Speed of the bomb
    public float cooldown = 2f; // Cooldown time in seconds

    private bool isCooldown = false;

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius && !isCooldown)
        {
            StartCoroutine(SpawnBomb());
        }
    }

    IEnumerator SpawnBomb()
    {
        isCooldown = true;

        // Instantiate the bomb
        GameObject bomb = Instantiate(bombPrefab, transform.position, Quaternion.identity);
        bomb.SetActive(true); // Ensure the bomb is active

        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Set the bomb's velocity to move towards the player
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        bombRb.velocity = direction * bombSpeed;

        // Wait for cooldown period
        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
    }
}
