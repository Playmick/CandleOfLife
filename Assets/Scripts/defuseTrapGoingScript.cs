using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defuseTrapGoingScript : MonoBehaviour
{

    private Contr2 other;
    private Animator anim;

    public void defuse()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)  
    {
         if (collision.gameObject.tag == "Player")
        {
            anim = collision.GetComponent<Animator>();
            other = collision.GetComponent<Contr2>() as Contr2;
            anim.SetBool("die", true);
            other.isDead = true;
        }
    }
    
}
