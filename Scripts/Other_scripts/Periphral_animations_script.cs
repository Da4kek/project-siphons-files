using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Periphral_animations_script : MonoBehaviour {
	public Animator animator;
	public movement script;
	public GameObject Player;
	public Health_UI weapon;

	// Use this for initialization
	void Start () {
		animator.SetBool ("death", false);
		script = Player.GetComponent<movement>();
	}
	
	// Update is called once per frame
	void Update () {
		WeaponCrouching ();
		if (weapon.weapondeath == true) 
		{
			animator.SetBool ("death", true);
		}
		
	}
	public void Death()
	{
		Destroy (gameObject);
	}
	void WeaponCrouching()
	{
		if (script.IsCrouching == true) {
			animator.SetBool ("crouch", true);
		} //else
			//animator.SetBool ("crouch", false);
		if (script.IsCrouching == false) 
		{
			animator.SetBool ("crouch", false);
		}
	}
}
