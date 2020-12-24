using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Audio_tracker_Enemy : MonoBehaviour {
	public AudioSource source;
	public  void EnemyHitAudio()
	{
        source = GetComponent<AudioSource>();
		source.pitch = (Random.Range(0.7f , 1f));
		source.Play ();
	}
}
