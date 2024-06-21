using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHoodMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;
    public SphereCollider collider; // Reference to the SphereCollider

    private bool isCooldown = false; 
    private bool isMoving = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>(); // Make sure to assign this in the inspector
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        if (x != 0 && x < 0)
        {
            sr.flipX = false;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = true;
        }

        // Check for jump input
       if (Input.GetKeyDown(KeyCode.Space) && !isCooldown && !isMoving)
        {
            StartCoroutine(MoveCollider());
        }
        
    }

    IEnumerator MoveCollider()
    {
        // Start moving
        isMoving = true;

        // Move collider up
        Vector3 originalPosition = collider.center;
        collider.center = new Vector3(collider.center.x, collider.center.y + 0.7f, collider.center.z);
        
        // Wait for 0.2 seconds
        yield return new WaitForSeconds(0.6f);

        // Move collider back to original position
        collider.center = originalPosition;

        // End moving
        isMoving = false;

        // Start cooldown
        isCooldown = true;

        // Wait for 1 second cooldown
        yield return new WaitForSeconds(0.25f);

        // End cooldown
        isCooldown = false;
    }

}
