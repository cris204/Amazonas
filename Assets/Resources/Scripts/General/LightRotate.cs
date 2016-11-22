using UnityEngine;
using System.Collections;

public class LightRotate : MonoBehaviour {

	private GameObject[] antorchasPrendidas = new GameObject[3]; 
	private GameObject[] antorchasApagadas = new GameObject[3]; 
	private bool dia;
	private float cambia=90f;

	private ParticleSystem antorcha;
	// Use this for initialization
	void Start () 
	{		
		dia = true;
		antorchasApagadas = GameObject.FindGameObjectsWithTag ("AntorchaApagada");
		antorchasPrendidas = GameObject.FindGameObjectsWithTag ("AntorchaPrendida");
		for (int i = 0; i < antorchasPrendidas.Length; i++)
			antorchasPrendidas [i].SetActive (false);

		for (int i = 0; i < antorchasPrendidas.Length; i++) {
			antorchasApagadas [i].GetComponentInChildren <ParticleSystem > ().Play();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.state == GameManager.gameState.normal) {
			transform.Rotate (0f, 0f * Time.deltaTime, 5f * Time.deltaTime, Space.World);
			cambia += 5f * Time.deltaTime;
		}
		if (cambia > 160f && cambia < 380f) {			
			ActivarAntorchas ();
			dia = false;
		}

		if (cambia > 370f) {
			ApagaAntorchas ();
			dia = true;
		}
	}

	void ActivarAntorchas()
	{
		
		if (dia) {
			for (int i = 0; i < antorchasPrendidas.Length; i++) {
				antorchasPrendidas [i].SetActive (true);
				antorchasPrendidas [i].GetComponentInChildren <ParticleSystem > ().Play ();
				antorchasPrendidas [i].GetComponentInChildren <AudioSource> ().Play ();
			}

			for (int i = 0; i < antorchasPrendidas.Length; i++) {
				antorchasApagadas [i].SetActive (false);
			}
			
		}
	}

	void ApagaAntorchas()
	{
		if (!dia) {
			for (int i = 0; i < antorchasPrendidas.Length; i++)
				antorchasPrendidas [i].SetActive (false);
			cambia = 0f;
			for (int i = 0; i < antorchasPrendidas.Length; i++) {
				antorchasApagadas [i].SetActive (true);
				antorchasApagadas [i].GetComponentInChildren <ParticleSystem > ().Play();
			}
		}

	}
}
