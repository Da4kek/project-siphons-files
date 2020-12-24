using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_run : StateMachineBehaviour {
	Transform player;
	Rigidbody2D rb;
	public float speed = 3.5f;
	enemy_script enemyScript;
	enemy enemyS;
	public float Attackrange = 3f;
	//enemy detection script
	public LayerMask Player;
	public float raydis;
	public float enemyfollowdis;
	public bool playerdetected = false; 
	Transform raycastobj;
	bool enemyright;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		raycastobj  = GameObject.FindGameObjectWithTag("raycast_object").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		enemyScript = animator.GetComponent<enemy_script>();
		enemyS = animator.GetComponent<enemy>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//enemy direction
		if (animator.transform.localEulerAngles.y == 0) {
			enemyright = true;
		} else if (animator.transform.localEulerAngles.y == 180) {
			enemyright = false;
		}
		Vector2 raypos = raycastobj.transform.position;
		Vector3 raydir1 = Vector3.right;
		Vector3 raydir2 = Vector3.left;
		RaycastHit2D hit1 = Physics2D.Raycast (raypos, raydir1, raydis, Player);
		RaycastHit2D hit2 = Physics2D.Raycast (raypos, raydir2, raydis, Player);
		Debug.DrawRay (raypos, raydir1 * raydis, Color.green);
		Debug.DrawRay (raypos, raydir2 * raydis, Color.green);
		float distance = Vector2.Distance (animator.transform.position, player.transform.position);
		if (hit1.collider != null && distance <= enemyfollowdis && enemyright == true ) {
			playerdetected = true;

		} else if (distance > enemyfollowdis) {
			
			enemyScript.LookAt ();
			playerdetected = false;
		}
		
		if (hit2.collider != null && distance <= enemyfollowdis && enemyright == false) {
			playerdetected = true;
		} else if (distance > enemyfollowdis)
		{
			enemyScript.LookAt ();
			playerdetected = false;
	    }
		
		if (playerdetected == true || enemyS.firstHit == true)
		{
			enemyScript.LookAt ();
			Vector2 target = new Vector2 (player.position.x, rb.position.y);
			Vector2 newpos = Vector2.MoveTowards (rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition (newpos);
			//Finding distance between enemy and the player
			if ((Vector2.Distance (player.position, rb.position) <= Attackrange))
			{
				animator.SetTrigger ("Attack");
			}
		}
		
	} 

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		// due to some issue the trigger should be reset to null using ResetTrigger
		animator.ResetTrigger ("Attack");
	}


}
