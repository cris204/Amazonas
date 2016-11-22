using UnityEngine;
using System.Collections;

public class RandomPosition : MonoBehaviour {
	[SerializeField]
	private float sizeOfRadiusSpawn;

	private SpawnEnemyAround enemySpawn;
	private GameObject choza;
	private float radioChoza;
	private Collider[] area;

	void Awake()
	{
		
		choza = GameObject.Find ("Collider");
	}

	void Start()
	{
		enemySpawn = GameObject.Find ("Center Of Scene").GetComponent <SpawnEnemyAround> ();
		radioChoza = choza.GetComponent <CapsuleCollider > ().radius;

	}

	// Update is called once per frame
	void Update () {
		DentroDeChoza ();
	
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (choza .transform .position, radioChoza*5f);
	}

	void DentroDeChoza ()
	{
		area = Physics.OverlapSphere (choza.transform.position, radioChoza * 5);
		if (0 < area.Length)
		{			
			foreach (Collider col in area) {
				if (col.gameObject.name == "DestinationPoint") {
					Vector2 random = Random.insideUnitCircle;
					Vector3 position = new Vector3 (random.x, transform.position.y, random.y);
					position = new Vector3 (position.x * enemySpawn.sizeOfRadiusSpawn, position.y, position.z * enemySpawn.sizeOfRadiusSpawn);
					transform.position = position;
				}
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("Niño trigger");
		if (col.transform.tag == "Kid" || col.transform.tag == "Home") 
		{
			Vector2 random = Random.insideUnitCircle ;
			Vector3 position = new Vector3 (random.x, transform.position.y, random.y);
			position = new Vector3 (position.x * enemySpawn .sizeOfRadiusSpawn , position.y, position.z * enemySpawn .sizeOfRadiusSpawn);
			transform.position = position;
		}
	}

	void OnTriggerStay(Collider col)
	{
		if (col.transform.tag == "Kid" || col.transform.tag == "Home") 
		{
			Vector2 random = Random.insideUnitCircle ;
			Vector3 position = new Vector3 (random.x, transform.position.y, random.y);
			position = new Vector3 (position.x * enemySpawn .sizeOfRadiusSpawn , position.y, position.z * enemySpawn .sizeOfRadiusSpawn);
			transform.position = position;
		}
	}
}
