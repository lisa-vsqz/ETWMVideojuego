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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            rb.AddForce(new Vector3(x,0,10));
            Debug.Log("a");
        }
    }

}
