using UnityEngine;
using System.Collections;
using System .Collections .Generic;
public class EnemyMove : MonoBehaviour {

	private Transform player;
	public float speed;
	private Vector3 moveDirection;
	private Rigidbody rigidbodyEnemy;

	private  float seconds;
	private float time;
	private float timeUpdate;
	private bool timer;
	private float timeToDisable;
	private SpawnEnemyAround enemySpawn;

	static private List <EnemyMove> enemiesPool;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		rigidbodyEnemy = GetComponent <Rigidbody> ();

		if (enemiesPool == null)
			enemiesPool = new List <EnemyMove> ();
		enemiesPool.Add (this);

	}

	void Start () {
		enemySpawn = GameObject.Find ("DestinationPoint").GetComponent <SpawnEnemyAround>();
		gameObject.SetActive (false);
	}

	void Update () {
		
	}

	protected void OnEnable()
	{
		moveDirection = (player.position - transform.position).normalized;
		moveDirection = new Vector3 (moveDirection.x * speed, rigidbodyEnemy.velocity.y, moveDirection.z * speed);
		transform.LookAt (player.transform);
		rigidbodyEnemy.velocity = moveDirection;
		StartCoroutine (TimeToDisable ());
	}

	protected void OnBecameInvisible()
	{
		StopAllCoroutines ();
		gameObject.SetActive (false);

	}

	IEnumerator TimeToDisable()
	{
		yield return new WaitForSeconds (5f);
		OnBecameInvisible ();
	}

	static public EnemyMove Spawn(Vector3 position, Transform rotation)
	{
		foreach (EnemyMove enemyPool in enemiesPool) 
		{
			if (enemyPool.gameObject.activeInHierarchy == false) 
			{
				position.y = position.y - 0.3f;
				enemyPool.transform.position = position;
				//Vector3 rightRotation = (rotation.position - enemyPool.transform.position).normalized;
				//enemyPool.transform.LookAt(rotation);

				enemyPool.gameObject.SetActive (true);

				return enemyPool;
			}
		}
		return null; 
	}

	protected void OnDestroy()
	{
		enemiesPool.Remove (this);
		if (enemiesPool.Count == 0)
			enemiesPool = null;
	}

}
