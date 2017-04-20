using UnityEngine;
using System.Collections;

public class KidsSpawn : MonoBehaviour {

	[SerializeField]
	GameObject kid;
	[SerializeField]
	GameObject spawn;

	void Awake(){
		spawn.transform.position=new Vector3(Random.Range(-20f,20f),0,Random.Range(-15f,15f));
	}
	void Start () {
		Instantiate (kid, spawn.transform.position, transform.rotation);
		GameManager.Instance.state = GameManager.gameState.normal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Spawn()
	{
		
	}
}

