using UnityEngine;
using System.Collections;
using System .Collections .Generic;
public class EnemyMove : MonoBehaviour {

	private Transform player;
	public float speed;
	private Vector3 moveDirection;
	private Rigidbody rigidbodyEnemy;

	public GameObject destinationPoint;
	private NavMeshAgent navMesh;
	private Vector3 positionDestinationPoint;

	private  float seconds;
	private float time;
	private float timeUpdate;
	private bool timer;
	private float timeToDisable;
	private float timePaused;
	private bool paused=false;

	private SpawnEnemyAround enemySpawn;

	static private List <EnemyMove> enemiesPool;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		rigidbodyEnemy = GetComponent <Rigidbody> ();
		navMesh = GetComponent <NavMeshAgent > ();

		if (enemiesPool == null)
			enemiesPool = new List <EnemyMove> ();
		enemiesPool.Add (this);
	}

	void Start () {
		enemySpawn = GameObject.Find ("DestinationPoint").GetComponent <SpawnEnemyAround>();
		gameObject.SetActive (false);
		timeToDisable = 5f;
	}

	void Update () {
		if (GameManager.Instance.state == GameManager.gameState.normal && this.gameObject .activeInHierarchy ==true) 
		{
			rigidbodyEnemy.velocity = moveDirection;
			if (paused) 
			{
				gameObject.GetComponentInChildren<Animator> ().enabled = true;
				StartCoroutine(TimeToDisable ());
				paused = false;
			}
		}
		if (GameManager.Instance.state == GameManager.gameState.pause) 
		{
			rigidbodyEnemy.velocity = new Vector3 (0f, 0f, 0f);
			if (!paused) 
			{
				gameObject.GetComponentInChildren<Animator> ().enabled = false;
				this.StopAllCoroutines ();
				paused = true;
			}
		}
	}

	protected void OnEnable()
	{
//	moveDirection = (player.position - transform.position).normalized;
	//	moveDirection = new Vector3 (moveDirection.x * speed, rigidbodyEnemy.velocity.y, moveDirection.z * speed);

		transform.LookAt (player.transform);
	//	navMesh.SetDestination (destinationPoint.transform.position);

	//	rigidbodyEnemy.velocity = moveDirection;
		StartCoroutine (TimeToDisable ());
	}

	protected void OnBecameInvisible()
	{
		StopAllCoroutines ();
		gameObject.SetActive (false);

	}

	void Paused()
	{
		if (!paused) 
		{
			StopCoroutine (TimeToDisable ());
			paused = true;
		}
	}

	IEnumerator TimeToDisable()
	{
		yield return new WaitForSeconds (timeToDisable );
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
