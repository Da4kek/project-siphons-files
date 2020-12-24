using UnityEngine.Audio;
using System;
using UnityEngine;

public class audio_manager : MonoBehaviour {
	public sound[] sounds; 
	// Use this for initialization
	void Awake () {
		foreach (sound s in sounds) 
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.vloume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}
	
	public void Play (string name)
	{
		sound s = Array.Find(sounds, sound => sound.name == name); // For finding the appropriate instance in the array
		if (s == null) 
		{ 
			Debug.LogWarning ("You didnt put the sound " + name + "dickhead!");
			return;

		}
		s.source.Play();

	}
}
