using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour {
	public int maxlife;
	public int currentlife;
	public Animator animator;
	public bool firstHit;
	public bool AlertState;

	//particle effect
	public GameObject enemyParticle;

// Ai sprite flip
	public AIPath aipath;
// Enemy Damage color

	// Use this for initialization
 	void Start () 
	{
		AlertState = false;
		//animator.SetBool ("death", false);
		//Material mymat = GetComponent<Renderer> ().material;
		firstHit = false;
		currentlife = maxlife;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (aipath.desiredVelocity.x >= 0.01f) {
			gameObject.transform.localScale = new Vector3 (1, 1, 1);
		} else if (aipath.desiredVelocity.x <= -0.01f) 
		{
			gameObject.transform.localScale = new Vector3 (-1, 1, 1);
		}
		
	}

	public void TakeDamage(int damage)
	{
		Instantiate (enemyParticle, transform.position, transform.rotation);
		//Material mymat = GetComponent<Renderer> ().material;
		//mymat.SetColor ("_Color", Color.white);
		animator.SetBool ("Get_Hit", true);
		firstHit = true;

		currentlife -= damage;
		if (currentlife == 0) 
		{
			Die ();
		}
	}
	public void Die ()
	{
		
		animator.SetBool ("death", true);
		Debug.Log ("Enemy died");
	}
	public void OnAnimationExit()
	{

		animator.SetBool ("Get_Hit", false);
	}
	public void Death()
	{
		Destroy (gameObject);
	}
}
