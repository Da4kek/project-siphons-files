using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour {
	public float movement_Speed = 10f;
	public float jump_height = 5f;
	public bool isGrounded;
	public bool candoublejump =true;
	public Rigidbody2D rigid;
	public float right;
    public float left;
	public Animator animator;
	private float horimove = 0f;
	public bool IsCrouching;
	//dash
	public float dashstart;
	public float dashcurrentTime;
	public float dashSpeed;
	public int direction;
	public GameObject dasheffect;
	public bool isdashing;
	//wall climbing
	public bool IsSliding;
	public LayerMask isWall;
	public Transform WallCheckPoint;
	public bool WallCheck;
	public bool isfacingRight;
	public float slideSpeed = -0.7f;
	public float slidethrottle = 0.1f;
	public float normalSlideSpeed;
	public bool isrunning;



	// Use this for initialization
	void Start () 
	{
		//isrunning = false;
		right = transform.eulerAngles.y;
		dashcurrentTime = dashstart;
		normalSlideSpeed = slideSpeed;
	} 

	void Update()
	{
		
		Crouch ();
		jump ();


	}


	// Update is called once per frame
	void FixedUpdate ()
	{
		WallClimbing ();


		horimove = Input.GetAxisRaw("Horizontal");
		animator.SetFloat("speed",Mathf.Abs(horimove));



		if (!WallCheck && !isdashing) 
			{
				if (Input.GetKey ("right")) {
					Vector3 Movement = new Vector3 (1f, 0f, 0f);
					transform.position += Movement * Time.deltaTime * movement_Speed;
					transform.eulerAngles = new Vector2 (transform.eulerAngles.x, right);

				} 


				if (Input.GetKey ("left")) {
					transform.eulerAngles = new Vector2 (transform.eulerAngles.x,180f );
					Vector3 Movement = new Vector3 (-1f, 0f, 0f);
					transform.position += Movement * Time.deltaTime * movement_Speed;


				} 
			}

		
		//input right left feedback
		if (Input.GetKey ("right")) 

			isfacingRight = true;

		if (Input.GetKey ("left")) 
			
			isfacingRight = false;
		Dash();


	}
	void jump()
	{
		if (isGrounded ||IsSliding) {
			animator.SetBool ("isjumping", false);
			
		} else if (!isGrounded && !IsSliding){
			animator.SetBool ("isjumping", true);
		}


		
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isGrounded && IsCrouching == false || IsSliding || isdashing) {
				FindObjectOfType<audio_manager> ().Play ("jumpsound");
				animator.SetTrigger ("takeoff");
				//animator.SetBool ("isjumping", true);
				//animator.SetBool ("isjumping", ture);
				rigid.velocity = new Vector2 (rigid.velocity.x, 0);
				Vector2 jump = new Vector2 (0f, jump_height);
				gameObject.GetComponent<Rigidbody2D> ().AddForce (jump, ForceMode2D.Impulse);
				candoublejump = true;
			} else {
				if (candoublejump|| isdashing) {
					animator.SetTrigger ("takeoff");
					FindObjectOfType<audio_manager> ().Play ("jumpsound");
					candoublejump = false;
					rigid.velocity = new Vector2 (rigid.velocity.x, 0);
					Vector2 jump = new Vector2 (0f, jump_height);
					gameObject.GetComponent<Rigidbody2D> ().AddForce (jump, ForceMode2D.Impulse);
				}
			}
		}


	}
		void Crouch()
		{
		if (Input.GetKey (KeyCode.C) && isGrounded) 
		{
			IsCrouching = true;
			animator.SetBool ("crouch", true);
		}
		if (Input.GetKeyUp (KeyCode.C)) 
		{
			IsCrouching = false;
			animator.SetBool ("crouch", false);
		}

		}
	void Dash ()
	{
		if (direction == 0) {
			if (Input.GetKeyDown(KeyCode.LeftShift) && !isfacingRight) {
				Instantiate (dasheffect, transform.position, Quaternion.identity);
				isdashing = true;
				direction = 1;



			} else if (Input.GetKeyDown (KeyCode.LeftShift)&& isfacingRight) {
				Instantiate (dasheffect, transform.position, Quaternion.identity);
				isdashing = true;
				candoublejump = true;
				direction = 2;
			}

		} else {
			if (dashcurrentTime <= 0) {// dash current time is hard corded in engine itself//
				direction = 0;
				isdashing = false;
				dashcurrentTime = dashstart;
				rigid.velocity = Vector2.zero;

			

			} else
				dashcurrentTime -= Time.deltaTime;// reducing current time with engine time


			if (direction == 1) {
				rigid.velocity = Vector2.left *Time.fixedDeltaTime*dashSpeed;

			}
			if (direction == 2) {
				rigid.velocity = Vector2.right *Time.fixedDeltaTime*dashSpeed;

			}
			
		}
	}
	void WallClimbing ()
	{
		if (isGrounded) {
			WallCheck = false;
			IsSliding = false;
		}

		if (!isGrounded) {
			WallCheck = Physics2D.OverlapCircle (WallCheckPoint.position, 0.1f, isWall);

			if (isfacingRight || !isfacingRight) {
				if (WallCheck) {
					HandleWallSliding();


				}
			}

			if (isGrounded || WallCheck == false) {
				IsSliding = false;
			}
		}
	}

	void HandleWallSliding()
	{
		rigid.velocity = new Vector2 (0f, slideSpeed); 
	    IsSliding = true;
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isfacingRight && Input.GetKey (KeyCode.RightArrow) && WallCheck) {

				rigid.AddForce (new Vector2 (-12f, 200f) * jump_height * Time.deltaTime, ForceMode2D.Impulse);

			}
				

			if (!isfacingRight && Input.GetKey (KeyCode.LeftArrow) && WallCheck) {
				rigid.AddForce (new Vector2 (12f, 200f) * jump_height * Time.deltaTime, ForceMode2D.Impulse);

			}
		}
	
	if (Input.GetKey (KeyCode.DownArrow)) {
	slideSpeed = slideSpeed - slidethrottle;
	} else
	{
	   slideSpeed = normalSlideSpeed;
    }
}


}


	

		