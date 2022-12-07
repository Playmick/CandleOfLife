using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defuseTrapScript : MonoBehaviour
{
	public GameObject trap;
	public GameObject but;
	
	private int t;
	
    bool check;
    bool endScript = true;
	
	void Start()
	{
		t=0;
	}
	
    private void Update()
    {
        if (endScript)
        {
            check = GetComponentInChildren<defuseTrapAreaScript>().yes;
            //CheckMarker();
        }
    }
	
	void FixedUpdate()
	{
		if (check == true) 
        {
			but.SetActive(false);
			t++;
			if(t>=50)
			{
				trap.transform.position = new Vector2(but.transform.position.x-17f, but.transform.position.y);
				
				endScript = false;
				check = true;
				t=0;
			}
		}
	}

}
