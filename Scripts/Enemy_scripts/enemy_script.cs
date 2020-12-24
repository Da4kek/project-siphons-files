using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour {
	public Transform player;
	public bool isFlipped = false;

	// Use this for initialization
	public void LookAt()
	{
		if (transform.position.x > player.position.x ) 
		{
			isFlipped = false;
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 180f,transform.eulerAngles.z);
		}
		if(transform.position.x <player.position.x) 
		{
			isFlipped = true;
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 0f,transform.eulerAngles.z);
		}
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
