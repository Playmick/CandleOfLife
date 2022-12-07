using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieScript : MonoBehaviour
{
    private Contr2 other;
    private Animator anim;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim = col.GetComponent<Animator>();
            other = col.GetComponent<Contr2>() as Contr2;
            anim.SetBool("die", true);
			anim.SetBool("chil", false);
			anim.SetBool("walk", false);
            other.isDead = true;
        }
    }
}
