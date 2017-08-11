using UnityEngine;
using System.Collections;

public class StopMusicOnGameScene : MonoBehaviour {

	public GameObject AudioObject;

	// Use this for initialization
	void Start () {
		AudioObject = GameObject.Find("GameObjectforaudio");
		Destroy(AudioObject);
	}

	// Update is called once per frame
	void Update ()
	{
		Destroy(AudioObject);
	}
}