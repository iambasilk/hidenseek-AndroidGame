using UnityEngine;
using System.Collections;
//starting the music when scene changes from gamescene to menuscene

public class Returntomenuscene : MonoBehaviour {
	
	//public AudioSource backgroundmusic;

	public void returntomenuscene()//back to menuscreen
	{


		Application.LoadLevel ("menuscreen");
		AudioListener.volume =1.0F;
		//backgroundmusic.Play();
		//DontDestroyOnLoad(this.gameObject);

	}




}
