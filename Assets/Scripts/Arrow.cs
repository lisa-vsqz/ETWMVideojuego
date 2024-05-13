using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    // [SerializeField] private float speed;
    // private float direction;
    // private bool hit;

    // private Animator anim;
    // private BoxCollider boxCollider;

    // private void Awake(){
    //     anim = GetComponent<Animator>();
    //     boxCollider = GetComponent<BoxCollider>();
    // }

    // private void Update(){
    //     transform.Translate(Vector3.forward * speed * Time.deltaTime);
    // }

    
    // private void OnTriggerEnter(Collider Collision){
    //     hit = true;
    //     boxCollider.enabled = false;
    //     anim.SetTrigger("explode");
    // }

    // public void SetDirection(float _direction){
    //     direction = _direction;
    //     gameObject.SetActive(true);
    //     hit = false;
    //     boxCollider.enabled = true;

    //     float localScaleX =  transform.localScale.x;
    //     if( Mathf.Sign(localScaleX) != _direction){
    //         localScaleX = -localScaleX;
    //     }
    //     transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    // }

    // private void DeActivate(){
    //     gameObject.SetActive(false);
    // }

    public float life = 3;
 
    void Awake()
    {
        Destroy(gameObject, life);
    }
 
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }


}
