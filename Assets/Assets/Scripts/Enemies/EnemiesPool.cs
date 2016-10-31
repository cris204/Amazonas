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
	private NavMeshAgent enemyPrefab;

	[SerializeField]
	private int size;

	private List<NavMeshAgent> enemies;

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
		enemies = new List<NavMeshAgent> ();
		for (int i = 0; i < size; i++)
			AddEnemy ();
	}

	public NavMeshAgent GetEnemy ()
	{
		if (enemies.Count == 0)
			AddEnemy ();
		return AllocateEnemy ();
	}

	public void ReleaseEnemy (NavMeshAgent enemy)
	{
		enemy.gameObject.SetActive (false);
		enemies.Add (enemy);
	}

	private void AddEnemy ()
	{
		NavMeshAgent instance = Instantiate (enemyPrefab);
		instance.gameObject.SetActive (false);
		enemies.Add (instance);
	}

	private NavMeshAgent AllocateEnemy ()
	{
		NavMeshAgent enemy = enemies [enemies.Count - 1];
		enemies.RemoveAt (enemies.Count - 1);
		enemy.gameObject.SetActive (true);
		return enemy;
	}
}
