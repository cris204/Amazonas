using UnityEngine;
using System.Collections;

public class EnemyCollision : EnemyMove {


	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Player")
			OnBecameInvisible ();
	}

}
