using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_weapon_script : MonoBehaviour {
	public float attackRange;
	public float attackDamage = 15f ;
	public LayerMask AttackMask;
	public Transform attackpoint;

	public void Attack()
	{
		Collider2D colinfo = Physics2D.OverlapCircle (attackpoint.position, attackRange, AttackMask);
		if (colinfo != null) 
		{
			colinfo.GetComponent<Health_UI>().Damage((int)attackDamage);
		}
      
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere (attackpoint.position, attackRange);
	}




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
