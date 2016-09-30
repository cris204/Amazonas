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
		
		gameObject.SetActive (false);
	}

	void Update () {
		
	}

	protected void OnEnable()
	{
		moveDirection = (player.position - transform.position).normalized;
		rigidbodyEnemy.velocity = moveDirection * speed;
		StartCoroutine (TimeToDisable ());
	}

	protected void OnBecameInvisible()
	{
		StopAllCoroutines ();
		gameObject.SetActive (false);
	}

	IEnumerator TimeToDisable()
	{
		yield return new WaitForSeconds (2f);
		OnBecameInvisible ();
	}

	static public EnemyMove Spawn(Vector3 position, Quaternion rotation)
	{
		foreach (EnemyMove enemyPool in enemiesPool) 
		{
			if (enemyPool.gameObject.activeInHierarchy == false) 
			{
				enemyPool.transform.position = position;
				enemyPool.transform.rotation = rotation;

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
