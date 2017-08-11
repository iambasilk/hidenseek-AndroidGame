using UnityEngine;
using System.Collections;

public class loadlevel : MonoBehaviour {

	public Canvas musicmenu;
	public Canvas howtoplaymenu;
	public Canvas highscoremenu;
	public AudioSource backgroundmusic;
	void Start()
	{
		highscoremenu.enabled = false;
		musicmenu.enabled = false;
		howtoplaymenu.enabled = false;
	}
	public void LoadStage()  {
		backgroundmusic.Stop();
		AudioListener.volume = 0.0F;
		Application.LoadLevel ("ingame_Scene");

	}
	public void LoadStagefromgame()  
	{
		
		Application.LoadLevel ("menuscreen");
	}

	public void showmusicmenu()
	{
		musicmenu.enabled = true;
	}
	public void showhowtoplaymenu()
	{
		howtoplaymenu.enabled = true;
	}
	public void hidehowtoplaymenu()
	{
		howtoplaymenu.enabled = false;
	}
	public void hidemusicmenu()
	{
		musicmenu.enabled = false;
	}
	public void showhighscoremenu()
	{
		highscoremenu.enabled = true;
	}
	public void hidehighscoremenu()
	{
		highscoremenu.enabled = false;
	}


}
