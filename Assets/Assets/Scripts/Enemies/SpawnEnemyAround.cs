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

	public GameObject contraPosition;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");	
		alert = GameObject.Find ("Alert!");
		alert.SetActive(false);
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, sizeOfRadiusSpawn);
	}

	void Start () {
	
	}

	void Update () {
		if (GameManager.Instance.state == GameManager.gameState.normal) {
			if (canSpawn) {
				canSpawn = false;
				StartCoroutine (SpawnEnemies ());
			}
		}
	}

	IEnumerator SpawnEnemies()
	{
		Vector3 oldPosition = transform.position;
		Vector2 random = (Random.insideUnitCircle).normalized ;
		Vector3 positionSpawn = new Vector3 (random.x, oldPosition .y, random.y);
		positionSpawn = new Vector3 (positionSpawn.x * sizeOfRadiusSpawn, positionSpawn.y, positionSpawn.z * sizeOfRadiusSpawn);
		alert.transform.position = positionSpawn;

		Vector3 contraVector = new Vector3 (-positionSpawn.x, positionSpawn.y, -positionSpawn.z);
		contraPosition.transform.position = contraVector;

		alert.SetActive (true);
		yield return new WaitForSeconds (spawnTime);
		alert.SetActive (false);
		Vector3 rotation = (contraPosition.transform.position - alert.transform.position).normalized;
		Quaternion finalRotaion = Quaternion.Euler (contraVector);

		EnemyMove.Spawn (positionSpawn, contraPosition .transform  ); 
		canSpawn = true;
	}
}

