using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class touchTest: MonoBehaviour {

	Ray ray;
	RaycastHit hit;

	public Text puzzletext;
	public Text hinttext;
	public Canvas PuzzleCanvas;
	public Canvas GameoverCanvas;
	public Canvas HintCanvas;
	public Canvas optionCanvas;
	public Canvas areyousuretoexit;
	public Canvas gotobjectcanvas;
	public Text Resulttext;
	//public Text Scoretext;

	string[] mytags = new string[] { "chair", "desk","Cauldron" };
	string randomselected=null;
	int randomselectedindex=0;

	string[] puzzles=new string[]{"I have four legs but can not walk I have a back and cannot talk? ","Skip to the place of work\nTouch nothing but look near\nOn the surface I do lurk"," It had a magical association for centuries."};//
	string[] hints=new string[]{"Relax","Time to Work","Must for kitchen"};

	int faultcount=0;int upcount=10;int downcount=5;

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
		randomselected=mytags[randomselectedindex];
		puzzletext.text=puzzles[randomselectedindex];
		hinttext.text=hints[randomselectedindex];

	}
	public string randomselect(){
		randomselected=null;


		  //randomselected = mytags[Random.Range (0, mytags.Length-1)];//
		randomselected=mytags[randomselectedindex];
		return randomselected;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) { //to quit from game
			areyousuretoexit.enabled = true;
			Application.Quit ();
		}
		//for (var i = 0; i < Input.touchCount; i++) {
			if (Input.touchCount > 0 || Input.GetTouch (0).phase == TouchPhase.Began) {

				ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);

				//Debug.DrawRay (ray.origin, ray.direction * 20, Color.red);

				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					Debug.Log ("Hit something");


					if (Input.GetTouch (0).tapCount == 2 && hit.transform.gameObject.tag == randomselected) {
						ScoreManager.score=  ScoreManager.score + upcount;
						Resulttext.text = "Congratulations You found Mojo";
					//	Scoretext.text = ScoreManager.score.ToString();
						Gameover();
					}
					else 
					if(Input.GetTouch (0).tapCount == 2 && hit.transform.gameObject.tag != randomselected){
						faultcount = faultcount + 1;
						ScoreManager.score = ScoreManager.score -downcount ;
						
					}
					if (faultcount > 4) {
						Resulttext.text="Oops!!You Failed to find Mojo ";
						//Scoretext.text = ScoreManager.score.ToString();
						Gameover ();
					}

				}
			}

		//}

       




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
		Application.LoadLevel ("ingame_Scene");
	}

}
