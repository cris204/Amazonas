using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class InstruccioneManager : MonoBehaviour {

	public Button arrowLeft;
	public Button arowRight;
	public GameObject [] pantallazos= new GameObject[2];

	public float axisXArrow;


	public bool pressAxisX=true;

	private int positionInstructions;


	// Use this for initialization
	void Start () 
	{
		pantallazos [1].SetActive (false);
		positionInstructions = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		axisXArrow = Input.GetAxis ("ArrowsY");

		if (axisXArrow != 0 && pressAxisX) 
		{
			pressAxisX = false;
			if (axisXArrow > 0)
				PressArrowRight ();
			if (axisXArrow < 0)
				PressArrowLeft ();
		}

		Debug.Log (axisXArrow);

		if (axisXArrow == 0)
			pressAxisX = true;

		if (positionInstructions == 0) {
			arrowLeft.gameObject.SetActive (false);
		} else 
		{
			arrowLeft.gameObject.SetActive (true);
		}

		if (positionInstructions == pantallazos .Length -1) {
			arowRight.gameObject.SetActive (false);  
		} else 
		{
			arowRight.gameObject.SetActive (true);  
		}
	}

	public void PressArrowLeft()
	{
		pantallazos [positionInstructions].SetActive (false);
		positionInstructions--;
		if (positionInstructions <= 0)
			positionInstructions = 0;
		pantallazos [positionInstructions].SetActive (true);
	}

	public void PressArrowRight()
	{
		pantallazos [positionInstructions].SetActive (false);
		positionInstructions++;
		if (positionInstructions > pantallazos.Length - 1)
			positionInstructions = pantallazos.Length - 1;
		pantallazos [positionInstructions].SetActive (true);
	}
}
