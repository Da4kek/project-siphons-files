using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour {
	public Transform target;
	public float speed = 200f; 
	public float nextWaypointDistance = 3f;
	public  Transform enemyGfx;

	Path path; // the generated path
	public int currentWaypoint =0;
	public bool reachEndofPath = false;

	Seeker seeker;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();
        InvokeRepeating ("UpdatePath", 0f, .5f);


	}
	void UpdatePath()
	{
		//seeker is responsible for creating path\
		if (seeker.IsDone()) {
			seeker.StartPath (rb.position, target.position, OnPathComplete);
		}
	}
	void OnPathComplete(Path p)//function which calls new path after the old path completes
	{
		if (!p.error) 
		{
			path = p; 
			currentWaypoint = 0; // resets to the way point

		}
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (path == null)
			return; //exit the function or go back  to the calling function

		if (currentWaypoint >= path.vectorPath.Count) {
			reachEndofPath = true;
			return; //exit the function or go back  to the calling function
		} else 
		{
			reachEndofPath = false;
		}

		Vector2 direction = ((Vector2)path.vectorPath [currentWaypoint] - rb.position).normalized;// unit vector is i =(1,0);
		Vector2 force = direction * speed * Time.deltaTime;
		rb.AddForce (force);
		float distance = Vector2.Distance (rb.position, path.vectorPath [currentWaypoint]);
		if (distance < nextWaypointDistance) //reached the current waypoint distance // keeps on updating when distance is lesser or current waypoint set itself to max malue
		{
			currentWaypoint++; // modifies current waypoint
		}

		if (force.x >= 0.01) 
		{
			enemyGfx.localScale = new Vector3 (1f, 1f, 1f);
		}
		if (force.x <= -0.01) 
		{
			enemyGfx.localScale = new Vector3 (-1f, 1f, 1f);
		}
	}
}
