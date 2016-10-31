using UnityEngine;
using System.Collections;

public class KidsCollision : MonoBehaviour {

	private BoxCollider colliderKid;

	public delegate void KidOnHouse();
	public static event KidOnHouse kidOnHouse;
	private GameObject mySpawn;

	void Awake()
	{
		colliderKid = GetComponent <BoxCollider > ();
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
			colliderKid.enabled = false;
			KidsMovement.Instance.caught = false;
			KidSafe ();
			StartCoroutine (DisableCollider ());
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

	public void KidSafe()
	{
		if (kidOnHouse != null)
			kidOnHouse();			
	}
}
