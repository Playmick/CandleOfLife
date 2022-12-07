using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class exitScript : MonoBehaviour
{
	public Font font;
    private bool finish = false;
    private GUIStyle guiStyle = new GUIStyle(); 
    private GUIStyle guiStyle1 = new GUIStyle();
   
    //public A player;
	public GameObject wd;
	private ButtonContr world1;
	
	public GameObject diamond;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            finish = true;
        }
        // changeLevel(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = font;

        guiStyle1.fontSize = 70;
        guiStyle1.normal.textColor = Color.white;
        guiStyle1.font = font;
		
		world1 = wd.GetComponent<ButtonContr>();
		PlayerPrefs.SetInt("next", 0);
    }

    private void OnGUI()
    {
        if (finish)
        {
            string deadMessage = "УРОВЕНЬ ПРОЙДЕН";
            GUI.Label(new Rect(Screen.width / 2 - 400, Screen.height /2 - 550, 500, 700), deadMessage, guiStyle1);
			
            string replayMessage = "Нажмите R для перезапуска";
            GUI.Label(new Rect(Screen.width - 750, Screen.height - 100, 500, 700), replayMessage, guiStyle);
            
			PlayerPrefs.SetInt("inGame", 0);
			
			PlayerPrefs.SetInt("next", 1);
			
			world1.StoppingGame();
        }
    }
	
	void FixedUpdate()
	{
		if (finish)
        {
			if (Input.GetKeyDown(KeyCode.R))
			{
				finish = false;
				diamond.SetActive(false);
			}
		}
	}
	
        /*
        private string[] levelName = { "level1", "level2" }; // список уровней по порядку

        private void changeLevel(string curLevel)
        {
            int ind = Array.IndexOf(levelName, curLevel);
            SceneManager.LoadScene(levelName[ind+1]);
        }
        */
    }
