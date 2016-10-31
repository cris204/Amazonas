using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;

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

	}

	void Start () {
		destino = GameObject.Find ("DestinationPoint");
		if (GameManager.Instance.state == GameManager.gameState.menu)
			destino = GameObject.Find ("PuntoDestinoNiño");
	}

	// Update is called once per frame
	void Update () {
		if (GameManager.Instance.state == GameManager.gameState.normal) {
			if (!caught)
				agente.SetDestination (destino.transform.position);
			else
				transform.position = player.transform.position;
		}
		if (GameManager.Instance.state != GameManager.gameState.normal) 
		{
			agente.SetDestination (transform .position);
		}

		if (SceneManager.GetActiveScene ().name == "MenuPrincipal")
			RunAcross ();			
	}

	void RunAcross ()
	{
		
	}
}
