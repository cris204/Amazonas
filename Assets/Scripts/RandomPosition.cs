using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {
	[SerializeField]
	private float sizeOfRadiusSpawn;
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Niño trigger");
		if (col.transform.tag == "Kid") 
		{
			Vector2 random = Random.insideUnitCircle ;
			Vector3 position = new Vector3 (random.x, transform.position.y, random.y);
			position = new Vector3 (position.x * sizeOfRadiusSpawn, position.y, position.z * sizeOfRadiusSpawn);
			transform.position = position;
		}
	}
}
