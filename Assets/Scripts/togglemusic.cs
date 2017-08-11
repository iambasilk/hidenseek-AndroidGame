using UnityEngine;
using System.Collections;

public class togglemusic : MonoBehaviour {

	// Used for music toggling
	public void hello (bool value) {
		if (value == false) {
			AudioListener.volume = 0.0F;
		}
		if (value == true) {
			AudioListener.volume = 1.0F;
		}
	}
	

}
