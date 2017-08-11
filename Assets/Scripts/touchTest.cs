using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class touchTest: MonoBehaviour {

	void OnEnable(){

		EasyTouch.On_DoubleTap += On_DoubleTap;
	}
	// Unsubscribe
	void OnDisable(){

		EasyTouch.On_DoubleTap -= On_DoubleTap;
	}
	// Unsubscribe
	void OnDestroy(){

		EasyTouch.On_DoubleTap -= On_DoubleTap;
	}




	public  Text puzzletext;
	public  Text hinttext;
	public Canvas PuzzleCanvas;
	public Canvas GameoverCanvas;
	public Canvas gotobjectcanvas;
	public Canvas HintCanvas;
	public Canvas optionCanvas;
	public Canvas areyousuretoexit;
	public Text Resulttext;
	//public Text Scoretext;

	 string[] mytags = new string[] { "chair", "desk","Cauldron" };
	string randomselected=null;
	 int randomselectedindex=0;

	string[] puzzles=new string[]{"I have four legs but can not walk and I cannot talk? ","Skip to the place of work\nTouch nothing but look near\nOn the surface I do lurk"," It had a magical association for centuries."};//
	string[] hints=new string[]{"We use for Relaxatoin","Time to Work","Must for kitchen"};

	int faultcount=0; int upcount=10; int downcount=5;

	// Use this for initialization
	void Start () {
		
		PuzzleCanvas.enabled = true;
		GameoverCanvas.enabled = false;
		HintCanvas.enabled = false;
		optionCanvas.enabled = false;
		areyousuretoexit.enabled = false;
		gotobjectcanvas.enabled = false;

		randomselectedindex = 0;
		randomselectedindex = Random.Range (0, mytags.Length);
		randomselected = null;
		randomselected=mytags[randomselectedindex];
		puzzletext.text=puzzles[randomselectedindex];
		hinttext.text=hints[randomselectedindex];
	}

	public void On_DoubleTap( Gesture gesture) 
	{
		Debug.Log( "doubled tapped");

		if (gesture.pickObject.tag == randomselected) 
		{
			Debug.Log ("cooooooooooooooooooooolllllman");
			ScoreManager.score = ScoreManager.score + upcount;
			HintCanvas.enabled = false;
			//randomselectedindex = 0;
			randomselectedindex = Random.Range (0, mytags.Length);
			//randomselected = null;
			randomselected=mytags[randomselectedindex];
			puzzletext.text=puzzles[randomselectedindex];
			hinttext.text=hints[randomselectedindex];

		
		}

		if (gesture.pickObject.tag !=randomselected)
		{
			Debug.Log( "wrongobject with faultcount="+faultcount);
			ScoreManager.score = ScoreManager.score -downcount ;
			faultcount++;
			if (faultcount > 2) 
			{  
				Resulttext.text="Oops!!You Failed to find Mojo ";
				Gameover ();

			}	

		}

	}



	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) { //to quit from game
			areyousuretoexit.enabled = true;

		}



					
	}

			

	public void showhint()
	{
		ScoreManager.score = ScoreManager.score -downcount ;
		HintCanvas.enabled = true;
		PuzzleCanvas.enabled = true;
	}
	public void showoptions()
	{
		optionCanvas.enabled = true;
	}
	public void closebox()
	{
		PuzzleCanvas.enabled = false;
	}
	public void closeoptionbox()
	{
		optionCanvas.enabled = false;
	}


	public void Gameover()
	{
		GameoverCanvas.enabled = true;
		HintCanvas.enabled = false;
		PuzzleCanvas.enabled = false;
		gotobjectcanvas.enabled = false;
	}



	public void doexit (){
		Application.Quit();
		#if UNITY_STANDALONE 
		Application.Quit();
				#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}

	public void dontexit(){
	areyousuretoexit.enabled = false;
	}
	public void gotobjectmessage(){
		gotobjectcanvas.enabled=true;
	}
	public void closesuccessbox()
	{
		gotobjectcanvas.enabled = false;
	}
	public void restartgame()//res
	{
		
		//SceneManager.LoadScene ("ingame_Scene");
		Application.LoadLevel ("ingame_Scene");

	}

}
