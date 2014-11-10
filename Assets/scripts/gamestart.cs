using UnityEngine;
using System.Collections;
using StartApp;

public class gamestart : MonoBehaviour {

	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;

	private int dimension = 0;

	private string lblAppName;
	private string lblMadeBy;
	private string lblSize;
	private string lblStartGame;
	private string lblSandbox;
	private string lblQuit;

	void Start () {

		#if UNITY_ANDROID
		  StartAppWrapper.addBanner( 
		                          StartAppWrapper.BannerType.AUTOMATIC,
		                          StartAppWrapper.BannerPosition.BOTTOM);
		#endif

	}

	void OnEnable() {
		lblAppName = gamestate.Instance.getLangString ("appName");
		lblMadeBy = gamestate.Instance.getLangString ("madeBy");
		lblSize = gamestate.Instance.getLangString ("size");
		lblStartGame = gamestate.Instance.getLangString ("startGame");
		lblSandbox = gamestate.Instance.getLangString ("sandbox");
		lblQuit = gamestate.Instance.getLangString ("quit");
	}
	
	// Our Startscreen GUI
	void OnGUI () 
	{
		buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.fontSize = 21;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		
		titleStyle = new GUIStyle(GUI.skin.label);
		titleStyle.fontSize = 40;
		titleStyle.alignment = TextAnchor.MiddleCenter;

		subTitleStyle = new GUIStyle(GUI.skin.label);
		subTitleStyle.fontSize = 21;
		subTitleStyle.alignment = TextAnchor.MiddleCenter;

		if (dimension == 0) {
			dimension = gamestate.Instance.getDimension ();
		}

		GUI.Label(new Rect(Screen.width/2-200, 30, 400, 40), lblAppName, titleStyle);
		GUI.Label(new Rect(Screen.width/2-200, 70, 400, 40), lblMadeBy, subTitleStyle);

		dimension = Mathf.RoundToInt(GUI.HorizontalSlider (new Rect (Screen.width/2-200,160,400,30), dimension, 2.0f, 11.0f));
		GUI.Label(new Rect(Screen.width/2-200, 130, 400, 40), lblSize + ":" +dimension, subTitleStyle);

		if(GUI.Button(new Rect (Screen.width/2-90, 190, 180, 60), lblStartGame, buttonStyle))
		{
			startGame(dimension, true);
		}

		if(GUI.Button(new Rect (Screen.width/2-90, 250, 180, 60), lblSandbox, buttonStyle))
		{
			startGame(dimension, false);
		}


		if(GUI.Button(new Rect (Screen.width/2-90, 350, 180, 60), lblQuit, buttonStyle))
		{
			Application.Quit();
		}



	}
	
	private void startGame(int dimension, bool game)
	{
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.openInstructions(dimension, game);
	}


	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.Quit(); 
		}
	}


}
