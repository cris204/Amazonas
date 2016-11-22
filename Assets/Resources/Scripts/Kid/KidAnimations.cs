using UnityEngine;
using System.Collections;

public class KidAnimations : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (KidsMovement.Instance.caught == true) {
			GetComponent<Animator > ().SetBool ("Libre", false);
		} else {
			GetComponent<Animator > ().SetBool ("Libre", true);
		}
	}
}
