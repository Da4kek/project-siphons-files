using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_check : MonoBehaviour {
	public GameObject Player;
	private movement _movementScript;
	public LayerMask Ground;
	public Transform playerpos;
	//public bool IsGrounded;
	public float raydis;
	// Use this for initialization
	void Start () {
		_movementScript = Player.GetComponent<movement>();

	}
	
	// Update is called once per frame
	public void Update () 
	{
		
		Vector2 raypos = playerpos.transform.position;
		Vector2 raydir = Vector2.down;
		Debug.DrawRay (raypos, raydir*raydis, Color.green);
		RaycastHit2D hit = Physics2D.Raycast (raypos,raydir,raydis,Ground);
		if (hit.collider != null) {
			_movementScript.isGrounded = true;
		} else
			_movementScript.isGrounded = false;
	}

	

	//private void OnCollisionEnter2D (Collision2D collision)
	//{
	//	if ( ) {
			//collision.collider.tag == "Ground"
			//_movementScript.isGrounded = true;

	//	}
	//}

	//private void OnCollisionExit2D (Collision2D collidor)
	//{


	//	_movementScript.isGrounded = false;

//	}

}
