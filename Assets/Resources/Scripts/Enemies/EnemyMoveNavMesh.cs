using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class EnemyMoveNavMesh : MonoBehaviour {
	
	private UnityEngine.AI.NavMeshAgent navMeshEnemy;
	[SerializeField ]
	private GameObject destinationPoint;
	private GameObject animators;
	private bool paused=false;
	private Vector3 positionPoint;
	private GameObject mySpawn;

	private void Awake()
	{
		navMeshEnemy = GetComponent <UnityEngine.AI.NavMeshAgent > ();
		animators = this.transform.GetChild (0).gameObject;
	}

	void Start()
	{
		paused = false;
		if (GameManager.Instance.state == GameManager.gameState.menu) {
			destinationPoint = GameObject.Find ("PuntoDestinoAnimales");
			mySpawn = GameObject.Find ("Spawn (1)");
			navMeshEnemy.speed = 10;
		}
	}

	void Update()
	{
		if ((GameManager.Instance.state == GameManager.gameState.normal || GameManager.Instance.state == GameManager.gameState.menu) && this.gameObject .activeInHierarchy ==true) 
		{
			if (paused) 
			{
				navMeshEnemy.SetDestination (destinationPoint.transform .position);
				animators.GetComponent <Animator > ().enabled = true;
				paused = false;
			}
		}

		if ((GameManager.Instance.state == GameManager.gameState.pause || GameManager.Instance.state == GameManager.gameState.menuPause)) 
		{
			if (!paused) 
			{
				navMeshEnemy.SetDestination (this.transform.position);
				animators.GetComponent <Animator > ().enabled = false;
				paused = true;
			}
		}

		if (GameManager.Instance.state == GameManager.gameState.menu) {
			RunAcross ();
		}

	}

	void RunAcross ()
	{
		
	}

	/*void OnEnable()
	{
		positionPoint = destinationPoint.transform.position;
		navMeshEnemy.SetDestination (destinationPoint.transform .position);
	}*/

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PuntoLlegada") {
			destinationPoint.transform.SetParent (this.gameObject.transform);
			EnemiesPool.Instance.ReleaseEnemy (navMeshEnemy);
		}

		if (other.gameObject.tag == "DestinoAnimales") 
		{
			transform.position = mySpawn.transform.position;
		}
	}



}
