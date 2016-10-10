using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int score;
	[SerializeField ]
	private int pointsPerKid;

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
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
		score = 0;
	}

	// Use this for initialization
	void Start () {
		
		KidsCollision.kidOnHouse += MoreScore;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void MoreScore()
	{
		score += pointsPerKid;
	}

	private void LessScore()
	{
		
	}

}
