using UnityEngine;
using System.Collections;
using UnityEngine .UI;
using UnityEngine.EventSystems ;
public class SelectCube : MonoBehaviour {

	private Animator animatorCube;
	public Animator cubeText;
	private float reachTime;
	private float actualTime;
	private float time;
	public EventSystem manejoBotones;
	public Button si;

	public Image  confirmacion;
	// Use this for initialization
	void Start () 
	{
		confirmacion.gameObject.SetActive (false);
		reachTime = 0.5f;
		actualTime = 0f;
		time = 0f;
		animatorCube = GetComponent <Animator> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(animatorCube .GetBool ("Golpe") == true)
			actualTime += Time.deltaTime;
		if (actualTime >= reachTime) 
		{
			animatorCube.SetBool ("Golpe",false);
			cubeText.SetBool ("Golpe", false );
			actualTime = 0;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") 
		{
			si.Select ();
			//manejoBotones.firstSelectedGameObject = si.gameObject;
			confirmacion.gameObject.SetActive (true);
			animatorCube.SetBool ("Golpe",true);
			cubeText.SetBool ("Golpe", true);
			GameManager.Instance.state = GameManager.gameState.menuPause;
		}
	}

	public void SelectNo()
	{
		confirmacion.gameObject.SetActive (false);
		GameManager.Instance.state = GameManager.gameState.normal;
	}
}
