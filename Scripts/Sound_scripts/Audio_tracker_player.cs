using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_tracker_player : MonoBehaviour {

	public void Attack1Audio()
	{
		FindObjectOfType<audio_manager> ().Play ("Sword_slash");
	}
	public void Attack2Audio()
	{
		FindObjectOfType<audio_manager> ().Play ("Sword_slash_2");
	}
}
