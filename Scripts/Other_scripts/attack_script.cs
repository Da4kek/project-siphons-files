using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_script : MonoBehaviour {
	public Animator animator;
	public LayerMask enemylayer;
	public Transform attackPoint;
	public float attackrange;
	public int Damagedelt;
	public int noOfClicks;
	private float LastClickedTime = 0f;
	public float MaxComboDelay = 1f;
	public Animator cameraobj;

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - LastClickedTime > MaxComboDelay) 
		{
			noOfClicks = 0;
			animator.SetBool ("attack1", false);
			animator.SetBool ("attack2", false);
			 
		
		}
		if (Input.GetKeyDown (KeyCode.J)) 
		{
			
			noOfClicks = Mathf.Clamp(noOfClicks,0,2);
			Attack1();
			Collider2D[] hitenemies = Physics2D.OverlapCircleAll (attackPoint.position, attackrange, enemylayer);
			foreach (Collider2D enemies in hitenemies) 
			{
			//execution of collider 2d
			enemies.GetComponent<enemy> ().TakeDamage (Damagedelt);
				cameraobj.SetTrigger ("shakeCam");
		    }



	}
	}


	void Attack1()
	{
		LastClickedTime = Time.time;//current time

		if (noOfClicks <= 1) {
			noOfClicks++;

			animator.SetBool ("attack1", true);
			animator.SetBool ("attack2", false);

			}
			
		} 
	public void Attack2()
	{
		animator.SetBool ("attack1", false);
		if (noOfClicks >= 2 ) {
			
			animator.SetBool ("attack2", true);


		}else
		animator.SetBool ("attack2", false);
	} 
	void OnAnimationExits()
	{
		noOfClicks = 0;
		
	}

	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
			return;
		
		Gizmos.DrawWireSphere (attackPoint.position, attackrange);
	}
   
}
