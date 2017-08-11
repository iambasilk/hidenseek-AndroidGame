using UnityEngine;
using System.Collections;
//continue music playing from loadscene to menuscene
public class audiocontinuity : MonoBehaviour {


	public AudioSource backgroundmusic;
	// Use this for initialization
	void Start () {
		
		backgroundmusic.Play();

		DontDestroyOnLoad(this.gameObject);
	}



}
