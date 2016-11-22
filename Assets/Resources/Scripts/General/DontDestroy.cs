using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;
public class DontDestroy : MonoBehaviour {

	public static DontDestroy instance = null;
			
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);  

		DontDestroyOnLoad (this.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneManager.GetActiveScene().name .Equals("Level1"))
		{
			Destroy (this.gameObject);
		}
	}
}
