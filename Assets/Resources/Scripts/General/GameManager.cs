using UnityEngine;
using System.Collections;
using UnityEngine .UI ;
using UnityEngine.SceneManagement ;

public class GameManager : MonoBehaviour {

	public int score;
	public int life;
	[SerializeField ]
	private int pointsPerKid;
	public int scoreKid=0;
	public float seconds;
	public float minutes;
	private float time;
	private float timeUpdate;
	private bool paused;
	public enum gameState{normal,pause,bonusSalta,bonusCorre,levelComplete,menu,menuPause};
	public gameState state = gameState .menu ; 

	public static GameManager instance;
	public static GameManager Instance
	{
		get{
			return instance;
		}
	}

	void Awake ()
	{
		paused = false;
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		score = 0;
		life = 5;
		GameManager.Instance.state = GameManager.gameState.menu;
	}

	// Use this for initialization
	void Start () {		
		KidsCollision.kidOnHouse += MoreScore;
		//time = Time.time - timeUpdate;
		time = Time.time - (Time .time -1);

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Start")) 
		{
			if (!paused) {				
				state = gameState.pause;
				paused = true;
			} else {
				state = gameState.normal;
				paused = false;
			}
		}
		if (state == gameState.normal) {
			timeUpdate = Time.time - (Time.time - 1);
			//score += (int)timeUpdate % 60;
			score += (int)timeUpdate;
		}
	}

	private void MoreScore()
	{
		scoreKid ++;
		score += pointsPerKid;
	}

	public void GameOver()
	{
		if (life <= 0)
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	private void LessScore()
	{
		
	}

	public void Resume()
	{
		state = gameState.normal;
		paused = false;
	}


}
