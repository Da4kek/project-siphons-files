using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack_02_finisher_script : StateMachineBehaviour {
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		animator.SetBool ("attack2", false);
	
	}
	
}
