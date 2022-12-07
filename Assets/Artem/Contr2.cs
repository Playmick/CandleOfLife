using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Contr2 : MonoBehaviour
{
    //public Texture2D tex;

    public Animator anim;
    public Rigidbody2D rb2D;
	public float speed;
	public bool isDead;
	
	//private Vector2 dirX;
	//private Vector2 dirY;
	
	private bool facingRight = true;
	private float h;
	private float v;
	
    //private Sprite mySprite;
    //private SpriteRenderer sr;

    void Awake()
    {
        //sr = gameObject.AddComponent<SpriteRenderer>();
        //rb2D = gameObject.AddComponent<Rigidbody2D>();
    }

    void Start()
    {
		anim.SetBool("chil", true);
		anim.SetBool("walk", false);
		anim.SetBool("die", false);
			
		isDead = false;
		
        //mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        //dirX = new Vector2(1f, 0);
		//dirY = new Vector2(0, 1f);
        //sr.color = new Color(0.9f, 0.9f, 0.0f, 1.0f);

        //transform.position = new Vector3(-2.0f, -2.0f, 0.0f);
        //sr.sprite = mySprite;
    }

    void FixedUpdate()
    {
		if(!anim.GetBool("die"))
		{
			v = Input.GetAxis("Vertical");
			h = Input.GetAxis("Horizontal");
		}
		else
		{
			v = 0;
			h = 0;
		}
		if (PlayerPrefs.HasKey("inGame"))
		{
			if (PlayerPrefs.GetInt("inGame")==1)
			{
				
				Move();
				if (h > 0 && !facingRight)
				Flip ();
				else if (h < 0 && facingRight)
				Flip ();
				if ((v!=0 || h!=0) && !anim.GetBool("die"))
				{
					anim.SetBool("chil", false);
					anim.SetBool("walk", true);
				}
				else
				{
					anim.SetBool("walk", false);
					if (!anim.GetBool("die"))
						anim.SetBool("chil", true);
				}
			}	
		}
    }
	
	void Update()
	{
		
	}
	
	private void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	private void Move()
	{
		var direction = new Vector2(h, v);
        rb2D.MovePosition(rb2D.position + direction * speed * Time.deltaTime);
	}
}
