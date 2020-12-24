using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_UI : MonoBehaviour {
 public int maxHealth = 100;
	public int currentHealth;
	public Health_bar healthbar;
	public Animator animator;
	public bool weapondeath;

	// Use this for initialization
	void Start ()
	{ 
		weapondeath = false;
		animator.SetBool ("death", false);
		currentHealth = maxHealth;	
		healthbar.SetMaxHealth (maxHealth);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.K)) 
		{
			Damage (20);
		}
		if (currentHealth <= 0f) 
		{
			animator.SetBool ("death", true);
			weapondeath = true;
		}
	}

	// sets damage
	public void Damage(int damage)
	{
		FindObjectOfType<audio_manager> ().Play ("Player_hurt");
		animator.SetBool ("Get_hit", true);
		//animator.SetTrigger ("get_hit");
		currentHealth -= damage;
		healthbar.SetHealth (currentHealth);
	}
	public void OnHitAnimationExit()
	{
		animator.SetBool ("Get_hit", false);
	}
	public void Death()
	{
		Destroy (gameObject);
		
	}
}
