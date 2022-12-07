using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class characterController : MonoBehaviour {

	public float maxSpeed = 10f;
    public float moveHorizontal;
    public float moveVertical;
    //public Transform groundCheck;
	//public float radius = 0.2f;

    bool facingRight = true;

    private Rigidbody2D playerRB;
    
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate () {

        //grounded = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);

        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        playerRB.velocity = new Vector2(moveVertical * maxSpeed, playerRB.velocity.y);
        playerRB.velocity = new Vector2(moveHorizontal * maxSpeed, playerRB.velocity.x);

        if (moveHorizontal > 0 && !facingRight)
			Flip ();
		else if (moveHorizontal < 0 && facingRight)
			Flip ();
        

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

	}
	
	private void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    
}	

