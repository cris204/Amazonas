using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	[SerializeField]
	private float movementSpeed = 3;
	[SerializeField]
	private float jumpPower = 15;
	private float ejeX;
	private float ejeZ;
	private Rigidbody rbPlayer;
	public bool touchFloor;

	 void Start()
	 {
		 characterController = GetComponent<CharacterController>();
		rbPlayer = GetComponent <Rigidbody > ();
	 }

	void Update ()
	{
		movementVector.x = Input.GetAxis ("LeftJoystickX") * movementSpeed;
		movementVector.z = Input.GetAxis ("LeftJoystickY") * movementSpeed;
		ejeX  = Input.GetAxis ("LeftJoystickX") ;
		ejeZ= Input.GetAxis ("LeftJoystickY") ;	

		if((GameManager .Instance.state ==  GameManager.gameState.normal || GameManager .Instance.state ==  GameManager.gameState.menu) )
		{
				
			if (touchFloor && KidsMovement.Instance.caught == false) {
				
				if (Input.GetButtonDown ("A")) {
					rbPlayer.velocity = new Vector3 (0, jumpPower, 0);
					touchFloor = false;
				}
				if (Input.GetButton ("X")) 
				{
					if (Input.GetButtonDown ("X") && movementSpeed <=3) 
					{			
						movementSpeed += 2;
						StartCoroutine (Impulse ());
					}
				}
			}

			Vector3 vectorToMove = new Vector3 (movementVector.x * movementSpeed, rbPlayer.velocity.y, movementVector.z * movementSpeed);
			if (rbPlayer .velocity .y <0f)
				vectorToMove = new Vector3 (movementVector.x * movementSpeed, rbPlayer.velocity.y*1f, movementVector.z * movementSpeed);
			movementVector = vectorToMove;
			rbPlayer.velocity = movementVector;
				
			if (movementVector.magnitude > 0.05f) {
				
				Vector3 movement = new Vector3(movementVector .x , 0.0f, movementVector .z );
				transform.rotation = Quaternion.LookRotation(movement);
			}
		}
	}

	IEnumerator Impulse()
	{
		yield return new WaitForSeconds (0.2f);
		movementSpeed -= 2;
	}
		 
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Piso") 
		{
			touchFloor = true;
		}
		if (other.gameObject.tag == "Jaguar" || other.gameObject.tag == "Cocodrilo") 
		{
			GetComponent<AudioSource> ().Play ();
			GameManager.Instance.life--;
			GameManager.Instance.GameOver ();
			KidsCollision .Instance .FallKid();
		}
	}

	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Piso") 
		{
			touchFloor = true;
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Piso") 
		{
			touchFloor = false;
		}
	}
	 
}
