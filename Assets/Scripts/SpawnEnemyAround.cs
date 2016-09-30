using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemyAround : MonoBehaviour {

	public GameObject enemy;
	public int sizeOfRadiusSpawn;
	public float spawnTime;

	private bool canSpawn=true;
	private GameObject player;

	private GameObject alert;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");	
		alert = GameObject.Find ("Alert!");
		alert.SetActive(false);
	}

	void Start () {
	
	}

	void Update () {
		if (canSpawn) {
			canSpawn = false;
			StartCoroutine (SpawnEnemies ());
		}
	}

	IEnumerator SpawnEnemies()
	{
		Vector3 oldPosition = transform.position;
		Vector2 random = (Random.insideUnitCircle).normalized ;
		Vector3 positionSpawn = new Vector3 (random.x, oldPosition .y, random.y);
		positionSpawn = new Vector3 (positionSpawn.x * sizeOfRadiusSpawn, positionSpawn.y, positionSpawn.z * sizeOfRadiusSpawn);
		alert.transform.position = positionSpawn;
		alert.SetActive (true);
		yield return new WaitForSeconds (spawnTime);
		alert.SetActive (false);
		EnemyMove.Spawn (positionSpawn, enemy.transform.rotation); 
		canSpawn = true;
	}
}

