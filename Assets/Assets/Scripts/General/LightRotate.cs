using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour {

	private GameObject[] antorchas = new GameObject[3]; 
	private bool dia;
	private float cambia=90f;
	// Use this for initialization
	void Start () 
	{
		dia = true;
		antorchas = GameObject.FindGameObjectsWithTag ("Antorcha");
		for (int i = 0; i < antorchas.Length; i++)
			antorchas [i].SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, 0f * Time.deltaTime, 5f * Time.deltaTime, Space.World);
		cambia += 5f * Time.deltaTime;
		if (cambia > 180f && cambia < 360f) {
			ActivarAntorchas ();
		}

		if (cambia > 370f)
			ApagaAntorchas ();
	}

	void ActivarAntorchas()
	{
		for (int i = 0; i < antorchas.Length; i++)
			antorchas [i].SetActive ( true);
	}

	void ApagaAntorchas()
	{
		for (int i = 0; i < antorchas.Length; i++)
			antorchas [i].SetActive  (false);
		cambia = 0f;
	}
}
