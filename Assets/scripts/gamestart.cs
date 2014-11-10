using UnityEngine;
using System.Collections;
using StartApp;
using System;

public class gamestart : MonoBehaviour {

	public Font guiFont;
	public Font titleFont;


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
		//guiFont.RequestCharactersInTexture ("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01234567890");

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
		int fontSize = (int)Math.Min((Screen.height / 600f) * 21f,(Screen.width / 600f) * 21f);


		titleStyle = new GUIStyle(GUI.skin.label);
		titleStyle.font = titleFont;
		titleStyle.fontSize = fontSize*2;;
		titleStyle.alignment = TextAnchor.MiddleCenter;

		subTitleStyle = new GUIStyle(GUI.skin.label);
		subTitleStyle.font = guiFont;
		subTitleStyle.fontSize = fontSize;
		subTitleStyle.alignment = TextAnchor.MiddleCenter;

		buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.font = guiFont;
		buttonStyle.fontSize = fontSize;
		buttonStyle.alignment = TextAnchor.MiddleCenter;

		Vector2 charSize = new Vector2 (fontSize,fontSize);

		GUI.skin.horizontalSliderThumb.fixedHeight = (int)(charSize.y *2.0f);
		GUI.skin.horizontalSliderThumb.fixedWidth = (int)charSize.x * 2.0f;
		GUI.skin.horizontalScrollbar.fixedHeight = (int)(charSize.y *2.0f);
		GUI.skin.horizontalScrollbar.fixedWidth = (int)(charSize.y *2.0f);
		GUI.skin.horizontalSlider.fixedHeight = (int)(charSize.y *2.0f);

		if (dimension == 0) {
			dimension = gamestate.Instance.getDimension ();
		}

		GUI.Label(new Rect(Screen.width/2-fontSize*20, fontSize*1, fontSize*40, fontSize*4), lblAppName, titleStyle);

		//FIX per problemi di caratteri mancanti su Android Nexus
		GUI.Label(new Rect(Screen.width/2-fontSize*20, fontSize*80, fontSize*40, fontSize*2), "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.", subTitleStyle);

		GUI.Label(new Rect(Screen.width/2-fontSize*20, fontSize*5, fontSize*40, fontSize*2), lblMadeBy, subTitleStyle);

		GUI.Label(new Rect(Screen.width/2-fontSize*20, fontSize*9, fontSize*40, fontSize*2), lblSize + ":" +dimension, subTitleStyle);
		dimension = Mathf.RoundToInt(GUI.HorizontalSlider (new Rect (Screen.width/6,fontSize*11,Screen.width/6*4,fontSize*2), dimension, 2.0f, 11.0f));

		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*14, fontSize*10, fontSize*3), lblStartGame, buttonStyle))
		{
			startGame(dimension, true);
		}

		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*17, fontSize*10, fontSize*3), lblSandbox, buttonStyle))
		{
			startGame(dimension, false);
		}


		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*21, fontSize*10, fontSize*3), lblQuit, buttonStyle))
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
