using UnityEngine;
using System.Collections;
using StartApp;

public class gamestart : MonoBehaviour {
	
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
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 20;

		if(GUI.Button(new Rect (30, 30, 150, 60), "Start Game 2",myButtonStyle))
		{
			startGame(2);
		}
		if(GUI.Button(new Rect (30, 90, 150, 60), "Start Game 3",myButtonStyle))
		{
			startGame(3);
		}
		if(GUI.Button(new Rect (30, 150, 150, 60), "Start Game 4",myButtonStyle))
		{
			startGame(4);
		}
		if(GUI.Button(new Rect (30, 210, 150, 60), "Start Game 5",myButtonStyle))
		{
			startGame(5);
		}
		if(GUI.Button(new Rect (30, 270, 150, 60), "Start Game 7",myButtonStyle))
		{
			startGame(7);
		}
		if(GUI.Button(new Rect (30, 330, 150, 60), "Start Game 9",myButtonStyle))
		{
			startGame(9);
		}
		if(GUI.Button(new Rect (30, 390, 150, 60), "Start Game 20",myButtonStyle))
		{
			startGame(20);
		}
		if(GUI.Button(new Rect (30, 480, 150, 60), "Quit",myButtonStyle))
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
