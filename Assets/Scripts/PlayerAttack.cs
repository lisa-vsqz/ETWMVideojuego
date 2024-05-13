using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // [SerializeField]  private float attackCooldown;
    // private Animator anim;
    // private RedHoodMovement redHoodMovement;
    // [SerializeField] private Transform firePoint;
    // [SerializeField] private GameObject charge;
    // private float coolDownTimer = Mathf.Infinity;
    // // Start is called before the first frame update
    // void Awake()
    // {
    //     anim = GetComponent<Animator>();
    //     redHoodMovement = GetComponent<RedHoodMovement>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.F) && coolDownTimer > attackCooldown){
    //         Attack();
    //     }

    //     coolDownTimer += Time.deltaTime;
    // }

    // private void Attack(){
    //     anim.SetTrigger("attack");
    //     coolDownTimer = 0;
    //     Instantiate(charge, firePoint.position, firePoint.rotation);
    // }


    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;

    private float nextFireTime;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            // Get the left direction of the cannon
            Vector3 leftDirection = transform.right;
            // Apply speed to the left direction
            bulletRb.velocity = leftDirection * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab does not have a Rigidbody component.");
        }
    }
}
