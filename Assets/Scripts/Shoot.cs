using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 30;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            // Use bulletSpawnPoint.forward to ensure the bullet moves forward along the spawn point's facing direction
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
