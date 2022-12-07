using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
	public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!audio.isPlaying)
		{
			audio.Play();
		}
    }
}
