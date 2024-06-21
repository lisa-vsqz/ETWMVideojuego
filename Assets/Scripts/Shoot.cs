using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;

    private RedHoodMovement redhoodMove; // Reference to RedHoodMovement script

    void Start()
    {
        // Assuming RedHoodMovement script is on the same GameObject as Shoot script
        redhoodMove = GetComponent<RedHoodMovement>();
    }

    void Update()
    {
        bulletSpawnPoint.localPosition = new Vector3(bulletSpawnPoint.localPosition.x, 0f, bulletSpawnPoint.localPosition.z);

        // Update bullet spawn point position based on player facing direction
        if (redhoodMove != null)
        {
            if (redhoodMove.sr.flipX)
            {
                bulletSpawnPoint.localPosition = new Vector3(1f, 0f, bulletSpawnPoint.localPosition.z); // Facing right
            }
            else
            {
                bulletSpawnPoint.localPosition = new Vector3(-1f, 0f, bulletSpawnPoint.localPosition.z); // Facing left
            }
        }
        else
        {
            Debug.LogWarning("RedHoodMovement component not found or assigned."); // Log a warning if component is missing
        }

        // Fire bullet when F key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.SetActive(true);  // Make sure the object is active

            // Set bullet velocity based on player facing direction
            if (redhoodMove != null)
            {
                if (redhoodMove.sr.flipX)
                {
                    bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.right * bulletSpeed; // Facing right
                }
                else
                {
                    bullet.GetComponent<Rigidbody>().velocity = -bulletSpawnPoint.right * bulletSpeed; // Facing left
                }
            }
        }
    }
}
