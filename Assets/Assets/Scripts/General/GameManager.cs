using UnityEngine;
using System.Collections;
using UnityEngine .UI ;

public class GameManager : MonoBehaviour {

	private int score;
	[SerializeField ]
	private int pointsPerKid;
	public Text scoreText;
	public Text plusKid;
	public int scoreKid=0;

	public float seconds;
	public float minutes;
	private float time;
	private float timeUpdate;
	private bool paused;
	public enum gameState{normal,pause,bonusSalta,bonusCorre};
	public gameState state = gameState .normal ; 

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
		ShowTexts ();
	}

	void ShowTexts()
	{
		scoreText.text = score.ToString();
		plusKid.text = scoreKid .ToString ();
	}

	private void MoreScore()
	{
		scoreKid ++;
		score += pointsPerKid;
	}

	private void LessScore()
	{
		
	}

}
