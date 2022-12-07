using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class timerGameOver : MonoBehaviour
{
    public Animator anim;
    public Font font;
    public Contr2 player;
    //private float timer;
    private bool less;

    private GUIStyle guiStyle = new GUIStyle(); 
    private GUIStyle guiStyleDead = new GUIStyle();
	
	private int t=0;
    
    //для esc
    //public float timerStop;
    //public bool isPause;
    //public bool guiPause;

    void Start()
    {
        PlayerPrefs.SetInt("timer", 60);
        less = false;

        guiStyle.fontSize = 40;
        guiStyle.normal.textColor = Color.white;
        guiStyle.font = font;

        guiStyleDead.fontSize = 70;
        guiStyleDead.normal.textColor = Color.white;
        guiStyleDead.font = font;

    }

    void Update()
    {
        if (!less && PlayerPrefs.GetInt("inGame") == 1 && !player.isDead)
            countDown();

        //для esc
        //Time.timeScale = timerStop;
        //if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        //{
        //    isPause = true;
        //}
        //else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        //{
        //    isPause = false;
        //}

        //if (isPause == true)
        //{
        //    timer = 0;
        //    guiPause = true;
        //}
        //else 
        //{
        //    timer = 1f;
        //    guiPause = false;
        //}
        /*if (Input.GetKeyDown(KeyCode.R) && PlayerPrefs.GetInt("inGame") == 1)
        {
            SceneManager.LoadScene("lvl1");
        }*/

    }

    private void countDown() 
	{
        //timer -= Time.deltaTime;
        if (PlayerPrefs.GetInt("timer") < 0)
        {
            less = true;
            anim.SetBool("die", true);
			anim.SetBool("walk", false);
			anim.SetBool("chil", false);
            //player.isDead = true;
			PlayerPrefs.SetInt("inGame", 0);
            //gameOver(); //что то напимер вывод кнопки "заного" и "выход"
        }
    }
    
	private void OnGUI()
    {
        if (PlayerPrefs.GetInt("inGame") == 1)
        {
            string text = "Свеча погаснет через " + PlayerPrefs.GetInt("timer").ToString();
            GUI.Label(new Rect(Screen.width - 650, Screen.height - 1050, 500, 700), text, guiStyle);
        }

        if ((anim.GetBool("die"))&&(PlayerPrefs.GetInt("inGame")==0))
        {
            string deadMessage = "ПОВЕЗЕТ В СЛЕДУЮЩИЙ РАЗ";
            GUI.Label(new Rect(Screen.width / 2 - 600 , Screen.height /2 - 550, 500, 700), deadMessage, guiStyleDead);

            string replayMessage = "Нажмите R для перезапуска";
            GUI.Label(new Rect(Screen.width - 750, Screen.height - 100, 500, 700), replayMessage, guiStyle);
			
        }
        
        //для esc
        //if (guiPause == true)
        //{
        //    Cursor.visible = true;// включаем отображение курсора
        //    if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 150f, 150f, 45f), "Продолжить"))
        //    {
        //        isPause = false;
        //        timer = 0;
        //        Cursor.visible = false;
        //    }
        //    if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 100f, 150f, 45f), "Сохранить"))
        //    {

        //    }
        //    if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2) - 50f, 150f, 45f), "Загрузить"))
        //    {

        //    }
        //    if (GUI.Button(new Rect((float)(Screen.width / 2), (float)(Screen.height / 2), 150f, 45f), "В Меню"))
        //    {
        //        isPause = false;
        //        timer = 0;
        //        Application.LoadLevel("lvl1"); // здесь при нажатии на кнопку загружается другая сцена, вы можете изменить название сцены на свое

        //    }
        //}
    }
	
	void FixedUpdate()
	{
		if((PlayerPrefs.GetInt("inGame") == 1))
		{
			t++;
			if (t>=50)
			{
				PlayerPrefs.SetInt("timer", PlayerPrefs.GetInt("timer")-1);
				t = 0;
			}
		}
	}
}
