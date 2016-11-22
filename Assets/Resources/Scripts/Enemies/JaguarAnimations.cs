using UnityEngine;
using System.Collections;

public class JaguarAnimations : MonoBehaviour {

	private Animator animations;
	public bool corre;

	public static JaguarAnimations instance;
	public static JaguarAnimations Instance
	{
		get { 
			return instance;
		}
	}

	void Awake()
	{
		animations = GetComponent <Animator > ();
	}

	// Use this for initialization
	void Start () 
	{
		instance = this;
		corre = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnEnable()
	{
		corre = false;
		animations.SetBool ("Corre", false);
	}

	public void AtacaJugador()
	{
		Debug.Log ("Ataca");
		corre = true;
		animations.SetBool ("Corre", true);
	}
}
