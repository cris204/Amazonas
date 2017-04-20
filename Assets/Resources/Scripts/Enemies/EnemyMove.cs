using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
public class EnemyMove : MonoBehaviour {

	private UnityEngine.AI.NavMeshAgent navMeshEnemy;
	[SerializeField ]
	private GameObject destinationPoint;
	private GameObject animators;
	private bool paused=false;
	private Vector3 positionPoint;
	private GameObject mySpawn;
	private GameObject player;
	private float radioPlayer;
	[SerializeField]
	private JaguarAnimations child;

	private Collider[] area;


	private void Awake()
	{
		navMeshEnemy = GetComponent <UnityEngine.AI.NavMeshAgent > ();
		animators = this.transform.GetChild (0).gameObject;
	}

	void OnEnable()
	{
		navMeshEnemy.speed = 10;
	}

	void Start()
	{
		player = GameObject.Find ("Player");
		radioPlayer = player.GetComponent <CapsuleCollider> ().radius;
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

		AtacaJugador ();
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (player  .transform .position, radioPlayer *7f);
	}

	void AtacaJugador ()
	{
		area = Physics.OverlapSphere (player.transform.position, radioPlayer * 5, 15-16);
		if (0 < area.Length)
		{			
			foreach (Collider col in area) {
				if (col.gameObject.transform .tag == "Jaguar") 
				{
					GetComponent<AudioSource > ().Play();
					navMeshEnemy.speed = 18f;
					child.AtacaJugador ();
				}
			}
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
