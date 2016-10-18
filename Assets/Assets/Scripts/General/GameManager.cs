using UnityEngine;
using System.Collections;
using UnityEngine .UI ;

public class GameManager : MonoBehaviour {

	private int score;
	[SerializeField ]
	private int pointsPerKid;
	public Text scoreText;

	public float seconds;
	public float minutes;
	private float time;
	private float timeUpdate;
	private bool paused;
	private enum gameState{normal,pause,bonusSalta,bonusCorre};

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
				paused = true;
				Time.timeScale = 0;
			} else {
				paused = false;
				Time.timeScale = 1;
			}
		}
		timeUpdate = Time.time - (Time .time -1);
		//score += (int)timeUpdate % 60;
		score += (int)timeUpdate ;
		ShowTexts ();
	}

	void ShowTexts()
	{
		scoreText.text = score.ToString();
	}

	private void MoreScore()
	{
		score += pointsPerKid;
	}

	private void LessScore()
	{
		
	}

}
