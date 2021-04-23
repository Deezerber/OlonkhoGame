using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public float speed;
   public float lifetime;
   public float distange;
   public int damage;
   public LayerMask whatIsSolid;
   public GameObject bulletEffect;


    private void Update() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distange, whatIsSolid);
        if(hitInfo.collider != null){
            if (hitInfo.collider.CompareTag("Enemy")){
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Instantiate(bulletEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);                      
        }
        transform.Translate(Vector2.up * speed *Time.deltaTime);
    }



}
