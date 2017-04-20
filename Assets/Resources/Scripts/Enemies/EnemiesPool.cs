using UnityEngine;
using System.Collections.Generic;

public class EnemiesPool : MonoBehaviour {

	private static EnemiesPool instance;

	public static EnemiesPool Instance
	{
		get
		{
			return instance;	
		}
	}

	[SerializeField]
	private UnityEngine.AI.NavMeshAgent[] enemiesPrefab;

	[SerializeField]
	private int size;

	private List<UnityEngine.AI.NavMeshAgent> enemies;

	private void Awake()
	{
		if (instance == null) {
			instance = this;
			PrepareEnemies ();
		} else
			Destroy (gameObject);
	}

	private void PrepareEnemies ()
	{
		enemies = new List<UnityEngine.AI.NavMeshAgent> ();
		for (int i = 0; i < size; i++)
			AddEnemy ();
	}

	public UnityEngine.AI.NavMeshAgent GetEnemy ()
	{
		if (enemies.Count == 0)
			AddEnemy ();
		return AllocateEnemy ();
	}

	public void ReleaseEnemy (UnityEngine.AI.NavMeshAgent enemy)
	{
		enemy.gameObject.SetActive (false);
		enemies.Add (enemy);
	}

	private void AddEnemy ()
	{
		int p = Random.Range (0, enemiesPrefab.Length);
		UnityEngine.AI.NavMeshAgent instance = Instantiate (enemiesPrefab [p]);
		instance.gameObject.SetActive (false);
		enemies.Add (instance);
	}

	private UnityEngine.AI.NavMeshAgent AllocateEnemy ()
	{
		UnityEngine.AI.NavMeshAgent enemy = enemies [enemies.Count - 1];
		enemies.RemoveAt (enemies.Count - 1);
		enemy.gameObject.SetActive (true);
		return enemy;
	}
}
