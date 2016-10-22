using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {
	private Animator playerAnimations;
	private float ejeX;
	private float ejeZ;
	private CharacterController  player;

	private bool paused=false;

	void Awake()
	{
		playerAnimations = GetComponent <Animator > ();
		player = GameObject.Find ("Player").GetComponent<CharacterController  > ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (GameManager.Instance.state == GameManager.gameState.normal && this.gameObject .activeInHierarchy ==true) 
		{
			if (paused) 
			{
				gameObject.GetComponentInChildren<Animator> ().enabled = true;
				paused = false;
			}
		}
		if (GameManager.Instance.state == GameManager.gameState.pause) 
		{
			if (!paused) 
			{
				gameObject.GetComponentInChildren<Animator> ().enabled = false;
				paused = true;
			}
		}

		ejeX  = Input.GetAxis ("LeftJoystickX") ;
		ejeZ= Input.GetAxis ("LeftJoystickY") ;	

		if(Input.GetButtonDown ("A")) ///Jump Animation
		{			
			playerAnimations.SetBool ("Jump", true);
			StartCoroutine (DisableJump ());
		}

		if (Input.GetButtonDown ("X")) 
		{			
			playerAnimations.SetBool ("Scroll", true);
			StartCoroutine (DisableScroll ());
		}

//
//		if (ejeX < 0.2f && ejeZ < 0.2f && ejeX > -0.2f && ejeZ >- 0.2f)
		if(player.velocity == new Vector3 (0,0, 0)) /// Idle Animation
			playerAnimations.SetBool ("Walk", false);
		else
			playerAnimations.SetBool ("Walk", true); ////Walk Animation
	}

	IEnumerator DisableScroll()
	{
		yield return new WaitForSeconds (0.85f);
		playerAnimations.SetBool ("Scroll", false);
	}

	IEnumerator DisableJump()
	{
		yield return new WaitForSeconds (0.85f);
		playerAnimations.SetBool ("Jump", false);
	}


}
