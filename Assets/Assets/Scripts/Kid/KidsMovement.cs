using UnityEngine;
using System.Collections;

public class KidsMovement : MonoBehaviour {

	private GameObject player;

	NavMeshAgent  agente;
	public GameObject destino;
	public bool caught;

	public static KidsMovement instance;
	public static KidsMovement Instance
	{
		get{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
		player = GameObject.FindGameObjectWithTag ("Player");
		caught = false;
		agente = GetComponent <NavMeshAgent > ();
		destino = GameObject.Find ("DestinationPoint");
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.state == GameManager.gameState.normal) {
			if (!caught)
				agente.SetDestination (destino.transform.position);
			else
				transform.position = player.transform.position;
		}
		if (GameManager.Instance.state == GameManager.gameState.pause) 
		{
			agente.SetDestination (transform .position);
		}
			
	}
}
