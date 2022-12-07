using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContr : MonoBehaviour
{
	public GameObject btPlay;
	public Animation animPlay;
	public GameObject btHelp;
	public Animation animHelp;
	public GameObject btExit;
	public Animation animExit;
	public GameObject cam;
	public GameObject player;
	public Animator animPlayer;
	public GameObject Help;
	
	private int t1;
	private int t2;
	private int t3;
	private bool StartAnim1;
	private bool StartAnim2;
	private bool StartAnim3;
	private Vector2 camRet;
	private bool ret = false;
	
    // Start is called before the first frame update
    void Start()
    {
        t1 = 0;
		t2 = 0;
		t3 = 0;
		PlayerPrefs.SetInt("inGame", 0);
		StartAnim1 = false;
		StartAnim2 = false;
		StartAnim3 = false;
		camRet = new Vector2(player.transform.position.x - 50f, player.transform.position.y);
		Help.SetActive(false);
		//var zero = 
    }
	
	public void OnClickPlay()
	{
		PlayerPrefs.SetInt("inGame", 1);
	}
	
	public void OnClickHelp()
	{
		Help.SetActive(true);
	}
	
	public void OnClickExit()
	{
		Application.Quit();
	}
	
	public void OnClickMenu()
	{
		PlayerPrefs.SetInt("inGame", 0);
	}
	
	public void StoppingGame()
	{
		//Debug.Log("Нажал Esc");
			PlayerPrefs.SetInt("inGame",0);
			
			if (ret)
			{
				StartAnim1 = true;
				StartAnim2 = true;
				ret = false;
			}
			
			if ((StartAnim1)&&(StartAnim2))
			{
				animPlay.Play("retPlay");
				StartAnim2=false;
				StartAnim1=true;
			}
			animPlayer.SetBool("walk", false);
			if(animPlayer.GetBool("die"))
			{
				animPlayer.SetBool("chil", false);
			}
			else 
			{
				animPlayer.SetBool("chil", true);
			}
	}
	
	public void PlayngGame()
	{
		PlayerPrefs.SetInt("inGame",1);
		StartAnim2 = false;
		StartAnim1= false;
		if (ret)
		{
			StartAnim2=true;
		}
		if(!animPlayer.GetBool("die"))
			{
				animPlayer.SetBool("chil", true);
				animPlayer.SetBool("walk", false);
			}
	}
	
	void FixedUpdate()
    {
		if (PlayerPrefs.HasKey("inGame"))
		{
			if (PlayerPrefs.GetInt("inGame")==1)
			{
				
				if ((player.transform.position.x - cam.transform.position.x)>2f)
				{
					
					cam.transform.Translate(Vector2.right  * (player.transform.position.x - cam.transform.position.x)*0.1f);
					
				}
				
				if ((player.transform.position.y - cam.transform.position.y)>2f)
				{
					
					cam.transform.Translate(Vector2.up * (player.transform.position.y - cam.transform.position.y)*0.1f);
					
				}
				
				if ((player.transform.position.x - cam.transform.position.x)<-2f)
				{
					
					cam.transform.Translate(Vector2.right * (player.transform.position.x - cam.transform.position.x)*0.1f);
					
				}
				
				if ((player.transform.position.y - cam.transform.position.y)<-2f)
				{
					
					cam.transform.Translate(Vector2.up * (player.transform.position.y - cam.transform.position.y)*0.1f);
					
				}
				
				if ((!StartAnim1)&&(!StartAnim2))
				{
					animPlay.Play();
					StartAnim1=true;
				}
				else if ((StartAnim1)&&(!StartAnim2))
				{
					t1++;
				}
				if ((t1>=25) && (t1<=50))
					animHelp.Play();
				if (t1>=50)
				{
					animExit.Play();
					StartAnim2 = true;
					StartAnim3 = true;
					t1 = 0;
				}
			}
		}
	}
	
    // Update is called once per frame
    void Update()
    {
		camRet = new Vector2(player.transform.position.x - 50f, player.transform.position.y);
		
		if (Input.GetKeyDown(KeyCode.R) && ((PlayerPrefs.GetInt("inGame")==1) || animPlayer.GetBool("die")||PlayerPrefs.GetInt("next")!=0))
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
			
			player.transform.position = new Vector2(22,10);
			cam.transform.position = new Vector2(22,10);
			Debug.Log(animPlayer.GetBool("die"));
			if (!animPlayer.GetBool("die"))
				ret = true;
			
			if (PlayerPrefs.GetInt("next")!=0)
			{
				ret = false;
				PlayerPrefs.SetInt("next", 0);
			}
			animPlayer.SetBool("die", false);
			animPlayer.SetBool("chil", true);
			animPlayer.SetBool("walk", false);
			PlayerPrefs.SetInt("timer",60);
			PlayngGame();
		}
		
		if (Input.GetKeyDown(KeyCode.Escape))
			Help.SetActive(false);
		
        //если игра была запущена(остановили)
		if (Input.GetKeyDown(KeyCode.Escape) && (PlayerPrefs.GetInt("inGame")==1) && !Help.activeInHierarchy)
		{
			StoppingGame();
		}
		
		//если игра была остановлена(запустили)	
		else if (Input.GetKeyDown(KeyCode.Escape) && (PlayerPrefs.GetInt("inGame")==0) && StartAnim3 && !Help.activeInHierarchy)
		{
			Debug.Log("Нажал Esc");
			PlayngGame();
		}
		
		if(animPlayer.GetBool("die"))
		{
			StoppingGame();
		}
		
		if (PlayerPrefs.GetInt("inGame")==0)
		{
			cam.transform.position = Vector2.MoveTowards ( cam.transform.position, camRet, 1f);
			if ((StartAnim1)&&(!StartAnim2))
			{
				//Debug.Log("++");
				t2++;
			}
			if ((t2>=25) && (t1<=50))
				animHelp.Play("retHelp");
			if (t2>=50)
			{
				animExit.Play("retExit");
				StartAnim2 = false;
				StartAnim1= false;
				t2 = 0;
			}
		}
		//если игра была остановлена
		
    }
}
