using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attach : MonoBehaviour {
	public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		gameObject.transform.position = player.transform.position;
		gameObject.transform.eulerAngles = player.transform.eulerAngles;
		
	}
}
