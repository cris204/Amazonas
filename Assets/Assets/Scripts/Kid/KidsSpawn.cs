using UnityEngine;
using System.Collections;

public class KidsSpawn : MonoBehaviour {

	[SerializeField]
	GameObject kid;

	// Use this for initialization
	void Start () {
		Instantiate (kid, transform.position, transform.rotation);
		GameManager.Instance.state = GameManager.gameState.normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		
	}
}

