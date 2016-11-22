using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemyAround : MonoBehaviour {

	public GameObject enemy;
	private NavMeshAgent enemies;

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
		NavMeshAgent enemy = EnemiesPool.Instance.GetEnemy ();
		GameObject destinationPoint = enemy.transform.GetChild (1).gameObject;

		//Crear un punto random en un circulo de dimension 1
		Vector2 random = (Random.insideUnitCircle).normalized ;  
		//Los enemigos estan en la posicion 'y' del jugador y se combina con las posiciones en los otros ejes.
		Vector3 positionSpawn = new Vector3 (random.x, player .transform .position .y, random.y);  // Se le asigna el random en 'y' al eje z para rotar el círculo
		//Se encuenra el punto final con el radio establecido en otra variable (sizeOfRadiusSpawn)
		positionSpawn = new Vector3 (positionSpawn.x * sizeOfRadiusSpawn, positionSpawn.y, positionSpawn.z * sizeOfRadiusSpawn);

		enemy.gameObject.transform.position = positionSpawn;

		alert.transform.position = positionSpawn;

		Vector3 contraVector = new Vector3 (-positionSpawn.x, 0.2f, -positionSpawn.z);
		contraPosition.transform.position = contraVector;
		destinationPoint.transform.position = contraVector;
		enemy.SetDestination (destinationPoint.transform .position);
		destinationPoint.transform.SetParent (null);
		alert.SetActive (true);
		yield return new WaitForSeconds (spawnTime);
		alert.SetActive (false);

		//EnemyMove.Spawn (positionSpawn, contraPosition .transform  ); 
		canSpawn = true;
	}
}

