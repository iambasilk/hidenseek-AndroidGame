using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashFade : MonoBehaviour
{
	//public AudioClip background; 
	public Image splashImage;
	public string loadLevel;

	IEnumerator Start()
	{
		

		splashImage.canvasRenderer.SetAlpha(0.0f);

		FadeIn();
		yield return new WaitForSeconds(2.5f);//scene wating seconds
		FadeOut();
		yield return new WaitForSeconds(2.5f);
		SceneManager.LoadScene(loadLevel);	//loading next scene
	}

	void FadeIn()
	{
		splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
	}

	void FadeOut()
	{
		splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
	}
}

