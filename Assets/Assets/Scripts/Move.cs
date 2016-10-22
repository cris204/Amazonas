using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;
	private float ejeX;
	private float ejeZ;

	 void Start()
	 {
		 characterController = GetComponent<CharacterController>();
	 }

	void Update ()
	{
		movementVector.x = Input.GetAxis ("LeftJoystickX") * movementSpeed;
		movementVector.z = Input.GetAxis ("LeftJoystickY") * movementSpeed;
		ejeX  = Input.GetAxis ("LeftJoystickX") ;
		ejeZ= Input.GetAxis ("LeftJoystickY") ;	

		if(GameManager .Instance.state ==  GameManager.gameState.normal)
			{
				
			if (characterController.isGrounded) {
				movementVector.y = 0;
				if (Input.GetButtonDown ("A")) {
					movementVector.y = jumpPower;
				}
				if (Input.GetButton ("X")) 
				{
					if (ejeX < 0.2f && ejeZ < 0.2f && ejeX > -0.2f && ejeZ > -0.2f) 
					{
						//characterController.
					}
				}
			}

			movementVector.y -= gravity * Time.deltaTime;
			characterController.Move (movementVector * Time.deltaTime);

			if (movementVector.magnitude > 0.05f) {
				
				Vector3 movement = new Vector3(movementVector .x , 0.0f, movementVector .z );
				transform.rotation = Quaternion.LookRotation(movement);



			//	Vector3 lookY= new Vector3 (0f,transform .position .y,0f);
			//	transform.LookAt (transform .position + movementVector);
			} else {
				
			}

			if (Input.GetButtonDown ("X")) 
			{			
				movementSpeed += 8;
				StartCoroutine (Impulse ());
			}
		}
	}

	IEnumerator Impulse()
	{
		yield return new WaitForSeconds (0.2f);
		movementSpeed -= 8;
	}
		 
	 
}
