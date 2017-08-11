using UnityEngine; 
using UnityEngine.UI; 
using System.Collections; 
public class ScoreManager : MonoBehaviour 
{
	public static int score; // The player's score static to all classes. 
	public static int highscore;//Static highscore to all classes
	public Text highscoreText;
	public Text scoretext;
	// Reference to the Text component. 
	void Start () 
	{ // Set up the reference. 
		//text = GetComponent <Text> (); 
		// Reset the score. 
		score = 0; 
		highscore = PlayerPrefs.GetInt("highscore");
	}
		void Update () 
	{ 
		if (score > highscore)
		{
			highscore = score;
			PlayerPrefs.SetInt("highscore", highscore);

			PlayerPrefs.Save();
		}
		// Set the displayed text to be the word "Score" followed by the score value. 
		highscoreText.text = "Highscore: " + highscore;
	scoretext.text = "Score: " + score; 
	} 

}