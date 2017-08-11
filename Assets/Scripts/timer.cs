using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;

public class timer : MonoBehaviour{

public float seconds = 59;
public int minutes = 1;


public Text timerLabel;

public Canvas PuzzleCanvas;
public Canvas GameoverCanvas;
public Canvas HintCanvas;



public void Gameover()
{
		GameoverCanvas.enabled = true;
		HintCanvas.enabled = false;
		PuzzleCanvas.enabled = false;
}


void Update ()
	{

		if (seconds <= 0) {
			
			seconds = 59;
			if (minutes > 1||minutes==1) {
				//Debug.Log (minutes);
				minutes--;


			} else {

				minutes = 0;
				seconds = 0;
	  
				timerLabel.text = string.Format ("{0:00} : {1:00} ", minutes, seconds);
			}

		} else {

			seconds -= Time.deltaTime;

		}
		if (minutes == 0 && seconds==0) {
			Gameover ();

		}
		

	}
}