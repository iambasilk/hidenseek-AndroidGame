
using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public GameObject doorObject;
	bool  openedDoor;
	void  Start (){
		openedDoor=true;
	}




	void  OnTriggerStay ( Collider other  ){
		if (openedDoor){
			doorObject.GetComponent<Animation>().Play();
			openedDoor=false;
			//Debug.Log("openeddoor");
		}
	}
}