using UnityEngine;
using System.Collections;

public class SpawnCharacters : MonoBehaviour {

	public GameObject character;
	public GameObject puntoDestino;

	// Use this for initialization
	void Start () {
		Instantiate (character, transform.position, transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
