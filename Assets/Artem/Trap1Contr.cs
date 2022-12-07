using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1Contr : MonoBehaviour
{
	public GameObject trap;
	private bool st; //Start
	private int t;
	
	
    void Start()
    {
        st = false;
		t = 0;
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Player")
        {
			st = true;
		}
	}
	
    void FixedUpdate()
    {
        if(st)
		{
			t++;
			if (t<50)
				trap.SetActive(true);
			if (t>=50)
				trap.SetActive(false);
			if (t>=150)
				t=0;
		}
    }
}
