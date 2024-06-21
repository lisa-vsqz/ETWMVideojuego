using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;

    private float nextFireTime;
    private RedHoodMovement redhoodMove; 

    void Awake()
    {
        Debug.Log("PlayerAttack script is Awake.");
    }

    void Start()
    {
        Debug.Log("Start method in PlayerAttack is being called.");
        // Manually finding the RedHoodMovement component in the parent
        redhoodMove = GetComponentInParent<RedHoodMovement>();

        if (redhoodMove == null)
        {
            Debug.LogError("RedHoodMovement script not found on parent.");
        }
        else
        {
            Debug.Log("RedHoodMovement script found on parent.");
        }
    }

    void Update()
    {
        Debug.Log("Update method in PlayerAttack is being called.");
        
        if (Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + 1f / fireRate;
        }

        // Adjust bullet spawn point position based on player facing direction
        if (redhoodMove != null)
        {
            Debug.Log("RedHoodMovement exists.");
            if (redhoodMove.sr.flipX)
            {
                Debug.Log("Moving spawn point to the left.");
                transform.localPosition = new Vector3(-0.851f, transform.localPosition.y, transform.localPosition.z);  // Move to left position
            }
            else
            {
                Debug.Log("Moving spawn point to the right.");
                transform.localPosition = new Vector3(0.851f, transform.localPosition.y, transform.localPosition.z);  // Move to right position
            }
        }
    }

    void FireBullet()
    {
        Debug.Log("FireBullet method called.");
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // Get the forward direction of the bullet spawn point
            Vector3 direction = transform.right;
            // Apply speed to the forward direction
            bulletRb.velocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
