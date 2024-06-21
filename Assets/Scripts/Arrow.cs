using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private Animator anim;
    private BoxCollider boxCollider;
    private Rigidbody rb;
    [SerializeField] private HealthEnemy enemyHealth;
    private float damage = 1;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!hit)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if(other.tag == "Enemy")
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    public void SetDirection(float _direction)
    {
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Abs(localScale.x) * Mathf.Sign(_direction);
        transform.localScale = localScale;
    }

    private void DeActivate()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
