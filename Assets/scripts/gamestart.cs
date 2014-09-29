using UnityEngine;
using System.Collections;
using StartApp;

public class gamestart : MonoBehaviour {

	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;

	private int dimension = 5;

	void Start () {

		#if UNITY_ANDROID
		  StartAppWrapper.addBanner( 
		                          StartAppWrapper.BannerType.AUTOMATIC,
		                          StartAppWrapper.BannerPosition.BOTTOM);
		#endif



	}
	
	// Our Startscreen GUI
	void OnGUI () 
	{
		buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = 20;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		
		titleStyle = new GUIStyle(GUI.skin.label);
		titleStyle.fontSize = 40;
		titleStyle.alignment = TextAnchor.MiddleCenter;

		subTitleStyle = new GUIStyle(GUI.skin.label);
		subTitleStyle.fontSize = 20;
		subTitleStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(Screen.width/2-200, 30, 400, 40), "CUBI", titleStyle);
		GUI.Label(new Rect(Screen.width/2-200, 70, 400, 40), "by Bartoleo", subTitleStyle);

		dimension = Mathf.RoundToInt(GUI.HorizontalSlider (new Rect (Screen.width/2-200,160,400,30), dimension, 2.0f, 11.0f));
		GUI.Label(new Rect(Screen.width/2-200, 130, 400, 40), "Size: "+dimension, subTitleStyle);

		if(GUI.Button(new Rect (Screen.width/2-90, 190, 180, 60), "Start Game",buttonStyle))
		{
			startGame(dimension, true);
		}

		if(GUI.Button(new Rect (Screen.width/2-90, 250, 180, 60), "Sandbox",buttonStyle))
		{
			startGame(dimension, false);
		}


		if(GUI.Button(new Rect (Screen.width/2-90, 350, 180, 60), "Quit",buttonStyle))
		{
			Application.Quit();
		}



	}
	
	private void startGame(int dimension, bool game)
	{
		print("Starting game");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState(dimension, game);


	}


	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.Quit(); 
		}
	}


}
