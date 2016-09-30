using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;

	 void Start()
	 {
		 characterController = GetComponent<CharacterController>();
	 }

	void Update ()
	{
		movementVector.x = Input.GetAxis ("LeftJoystickX") * movementSpeed;
		movementVector.z = Input.GetAxis ("LeftJoystickY") * movementSpeed;

		if (characterController.isGrounded) {
			movementVector.y = 0;
			if (Input.GetButton ("A")) {
				movementVector.y = jumpPower;
			}
		}

		/*if (Input.GetButton ("X")) 
		{			
			characterController.velocity = characterController.velocity*10f;
			StartCoroutine (Impulse ());
		}*/

		movementVector.y -= gravity * Time.deltaTime;
		characterController.Move (movementVector * Time.deltaTime);

		if (movementVector.magnitude > 0.05f) 
		{
			Vector3 rotateVector = new Vector3 (0f,movementVector.y,0f);
			rotateVector = rotateVector.normalized;
			transform.Rotate( rotateVector);
		//	transform.LookAt (transform.position + movementVector);
		}
	}

/*	IEnumerator Impulse()
	{
		yield return new WaitForSeconds (0.3f);
		characterController.velocity = characterController.velocity/10f;
	}*/
		 
	 
}
