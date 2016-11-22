using UnityEngine;
using System.Collections;

public class KidsCollision : MonoBehaviour {

	private BoxCollider colliderKid;
	[SerializeField]
	private ParticleSystem safeParticles;
	public delegate void KidOnHouse();
	public static event KidOnHouse kidOnHouse;
	private GameObject mySpawn;
	[SerializeField]
	private GameObject player;

	public static KidsCollision instance;
	public static KidsCollision Instance
	{
		get{
			return instance;
		}
	}

	void Awake()
	{
		instance = this;
		colliderKid = GetComponent <BoxCollider > ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Use this for initialization
	void Start () 
	{
		if (GameManager.Instance.state == GameManager.gameState.menu) {			
			mySpawn = GameObject.Find ("Spawn (1)");
		}	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
			KidsMovement.Instance.caught = true;
		if (other.gameObject.tag == "Home" && KidsMovement .Instance .caught) 
		{
			GetComponent <AudioSource > ().Play ();
			Instantiate (safeParticles, new Vector3 (player.transform.position .x,player.transform.position.y + 1f, player.transform .position .z), transform.rotation);
			KidSafe ();
			FallKid ();
		}

		if (other.gameObject.tag == "DestinoNiño") 
		{
			transform.position = mySpawn.transform.position;
		}
	}

	IEnumerator DisableCollider()
	{
		yield return new WaitForSeconds (0.5f);
		colliderKid.enabled = true;
	}

	public void FallKid()
	{
		colliderKid.enabled = false;
		KidsMovement.Instance.caught = false;
		StartCoroutine (DisableCollider ());
	}

	public void KidSafe()
	{
		if (kidOnHouse != null)
			kidOnHouse();			
	}
}
