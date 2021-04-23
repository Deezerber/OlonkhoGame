using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm; 
    public bool one;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            startAnim.SetBool("StartOpen", true);
           
        }
       
    }

    public void OnTriggerExit2D(Collider2D other)
    {
         if(other.gameObject.tag == "Player")
        {
           startAnim.SetBool("StartOpen", false);
        dm.EndDialogue();

        }
        
    }
}
