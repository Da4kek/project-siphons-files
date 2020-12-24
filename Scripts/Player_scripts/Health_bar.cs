﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_bar : MonoBehaviour {
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public void SetMaxHealth(int Health)
	{
		slider.maxValue = Health;
		slider.value = Health;
		fill.color = gradient.Evaluate (1f);
	}


	public void SetHealth (int Health)
	{
		slider.value = Health;
		fill.color = gradient.Evaluate (slider.normalizedValue);//normalised value for going between 0 and 1 as gradien max an min value is 0 an 1
			

	}
}
