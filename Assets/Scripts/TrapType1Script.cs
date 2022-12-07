using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapType1Script : MonoBehaviour
{

    public GameObject[] trap = new GameObject[1];
    public float timer, interval = 3f;
    private bool less;

    // Start is called before the first frame update
    void Start()
    {
        less = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            if (less)
            {
                foreach(GameObject i in trap)
                    i.SetActive(true);
                less = false;
            }
            else  {
                foreach (GameObject i in trap)
                    i.SetActive(false);
                less = true;
                }

            timer = 0;
        }
    }
}
