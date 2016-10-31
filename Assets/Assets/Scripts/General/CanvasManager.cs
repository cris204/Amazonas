using UnityEngine;
using System.Collections;
using UnityEngine .UI;
using UnityEngine.SceneManagement ;

public class CanvasManager : MonoBehaviour {

	public GameObject levelComplete;
	public GameObject pauseCanvas;
	public GameObject inGameCanvas;
	public Text scoreText;
	public Text plusKid;

	// Use this for initialization
	void Start () 
	{
		levelComplete.SetActive (false);
		pauseCanvas.SetActive (false );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameManager.Instance.scoreKid == 5) {
			GameManager.Instance.state = GameManager.gameState.levelComplete;
			LevelComplete ();
		}

		if (GameManager.Instance.state == GameManager.gameState.pause) 
		{
			inGameCanvas.SetActive (false);
			pauseCanvas.SetActive (true);
		}

		if (GameManager.Instance.state == GameManager.gameState.normal) 
		{
			inGameCanvas.SetActive (true);
			pauseCanvas.SetActive (false);
		}
		ShowTexts ();
	}

	void ShowTexts()
	{
		scoreText.text = GameManager.Instance .score.ToString();
		plusKid.text =  GameManager.Instance . scoreKid .ToString ();
	}

	void LevelComplete()
	{
		levelComplete.SetActive (true);
		SceneManager.LoadScene ("Level1");
	}
}
