using UnityEngine;
using System.Collections;
using StartApp;

public class gamestart : MonoBehaviour {

	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;

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

		if(GUI.Button(new Rect (Screen.width/2-90, 120, 180, 60), "Start Game 2",buttonStyle))
		{
			startGame(2);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 180, 180, 60), "Start Game 3",buttonStyle))
		{
			startGame(3);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 240, 180, 60), "Start Game 4",buttonStyle))
		{
			startGame(4);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 300, 180, 60), "Start Game 5",buttonStyle))
		{
			startGame(5);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 360, 180, 60), "Start Game 7",buttonStyle))
		{
			startGame(7);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 420, 180, 60), "Start Game 9",buttonStyle))
		{
			startGame(9);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 480, 180, 60), "Start Game 20",buttonStyle))
		{
			startGame(20);
		}
		if(GUI.Button(new Rect (Screen.width/2-90, 540, 180, 60), "Quit",buttonStyle))
		{
			Application.Quit();
		}
	}
	
	private void startGame(int dimension)
	{
		print("Starting game");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState(dimension);


	}


	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.Quit(); 
		}
	}


}
