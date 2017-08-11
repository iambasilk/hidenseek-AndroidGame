using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//saving and retreiving high score from player prefs
public class Highscorebutton : MonoBehaviour {

	public Text highscoreText;

	void Start()
	{

		ScoreManager.highscore = PlayerPrefs.GetInt("highscore");
		highscoreText.text = ScoreManager.highscore.ToString();

	}
	void Update(){
		
		highscoreText.text = ScoreManager.highscore.ToString();
	}



}
