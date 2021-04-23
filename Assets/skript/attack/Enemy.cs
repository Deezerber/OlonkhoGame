using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int health;

    [SerializeField] 
    public float speed;
    public GameObject deathEffect;
    public int damage;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private PlayerControlller player;
    private Animator anim;

    [SerializeField] 
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
     [SerializeField] 
     public float agroRange;
    Rigidbody2D rb2;


    private void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerControlller>();
        normalSpeed = speed;

    }

    private void Update() {
        //distance check to player
        float distToPlayer = Vector2.Distance(transform.position, attackPos.position);

        if(distToPlayer<agroRange)
        {
            ChasePlayer();
        }
        else
        {           
           StopChasingPlayer();
            
        }

        if(stopTime<=0)
         {
             speed = normalSpeed;
         }
         else
         {
             speed = 0;
             stopTime -= Time.deltaTime;
         }

        if(health <= 0)
        {
            Die();
            // anim dead
        }

      
        
    }

    void ChasePlayer()
    {
       if(transform.position.x < attackPos.position.x)
       {
           //enemy is ti Left side for the Player, so move right
           rb2.velocity = new Vector2(speed, 0);
           transform.localScale = new Vector2(1,1);
       }
       else if(transform.position.x > attackPos.position.x)
       {
           //enemy is ti Right side for the Player, so move left
           rb2.velocity = new Vector2(-speed, 0);
           transform.localScale = new Vector2(-1,1);  
       }
        //enemy преследование за игроком
       
    }

     void StopChasingPlayer()
     {
         rb2.velocity = new Vector2(0, 0);
     }

    public void TakeDamage(int damage){
        
        health -= damage;
        //play damage amitation

         stopTime = startStopTime;
        
    }
    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

     public void OnTriggerEnter2D(Collider2D other) {
         if(other.CompareTag("Player"))
         {
             if(timeBtwAttack <= 0)
             {
                 anim.SetTrigger("enemyAttack");
                 
             }
             else
             {
                 timeBtwAttack -= Time.deltaTime;
             }
         }
     }

    public void OnEnemyAttack()
    {
        Instantiate(deathEffect, player.transform.position, Quaternion.identity);
        player.health -= damage;
        timeBtwAttack = startTimeBtwAttack;
    }
}
