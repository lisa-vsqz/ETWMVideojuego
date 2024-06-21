using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float followRadius = 8.0f; // Start following the player within this radius
    public float stopRadius = 5.0f; // Stop following the player within this radius
    public float groundDist = 0.7f;
    public float stoppingDistance = 2f;
  //  private float cooldownTimer = Mathf.Infinity;

    public LayerMask terrainLayer;
    public Transform player;
    private Animator anim;
    
    private Rigidbody rb;
    private SpriteRenderer sr;
    private Transform spriteTransform;
     [SerializeField] private HealthEnemy enemyHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
        sr = spriteTransform.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (player == null) return; 
        

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        

        if (distanceToPlayer <= followRadius && distanceToPlayer > stoppingDistance)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 moveDirection = new Vector3(direction.x, 0, direction.z);
            rb.velocity = moveDirection * speed;

            // Adjust height to follow the terrain
            AdjustHeight();

            // Flip the sprite based on movement direction
            if (direction.x < 0)
            {
                sr.flipX = true;
            }
            else if (direction.x > 0)
            {
                sr.flipX = false;
            }
        }
        else if (distanceToPlayer <= stopRadius)
        {
            rb.velocity = Vector3.zero; // Stop moving when within the stop radius
            anim.SetTrigger("attack");



        }

        
    }

    void AdjustHeight()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1; // Start the raycast slightly above the enemy

        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }
    }
}



