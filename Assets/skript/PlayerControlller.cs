using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControlller : MonoBehaviour
{
  public float speed;
  public float JumpForce;
  private float moveInput;
  public float health;
  public int numOfHearts;
  public Image[] hearts;
  public Sprite fullHeart;
  public Sprite emptyHeart;
  public Joystick joystick;

  private Rigidbody2D rb;

  private bool facingRight = true;
  
  private bool isGrounded;
  public Transform feetPos;
  public float checkRadius;
  public LayerMask whatIsGround;

  private Animator anim;

  private void Start()
  {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
  }

  private void FixedUpdate()
  {
      if(health > numOfHearts)
         {
            health = numOfHearts;
         }  
      for (int i = 0; i<hearts.Length; i++)
         {
             if (i < Mathf.RoundToInt(health))
             {
                 hearts[i].sprite = fullHeart;
             }
             else
             {
                 hearts[i].sprite = emptyHeart;
             }
             if(i < numOfHearts)
             {
                 hearts[i].enabled = true;
             }
             else 
             {
                 hearts[i].enabled = false;
             }
             if(health < 1)
             {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
             }
         }

      moveInput = joystick.Horizontal;
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
      if(facingRight == false && moveInput > 0)
      {
          Flip();
      }
      else if (facingRight == true && moveInput < 0)
      {
          Flip();
      }
      if (Mathf.Approximately(moveInput, 0))
      {
          anim.SetBool("isRunning", false); //анимация бега
      } 
      else 
      {
          anim.SetFloat("horSpeed", Mathf.Abs(moveInput));
          anim.SetBool("isRunning", true); //анимация бега
      }
  }

  private void Update()
  {
      float verticalMove = joystick.Vertical;
      
      isGrounded = Physics2D.OverlapCircle(feetPos.position,  checkRadius, whatIsGround);

  }

public void OnJumpButtonDown()
{
    if (isGrounded == true)
       {
            rb.velocity = Vector2.up * JumpForce;
            anim.SetTrigger("jump");
       }
}   

  void Flip()
  {
      facingRight =!facingRight;
      Vector3 Scaler = transform.localScale;
      Scaler.x *= -1;
      transform.localScale =Scaler;
  }
    
}
