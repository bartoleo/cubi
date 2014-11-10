using UnityEngine;
using System.Collections;
using System;

public class instructions : MonoBehaviour {

	public Font guiFont;
	public Font titleFont;
	
	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;
	private GUIStyle textStyle;

	private string lblAppName;
	private string lblInstructions;
	private string lblInstructionsText;
	private string lblStart;
	private string lblBackToMenu;

	private int dimension = 5;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable() {
		lblAppName = gamestate.Instance.getLangString ("appName");
		lblInstructions = gamestate.Instance.getLangString ("instructions");
		if (gamestate.Instance.isGame ()) {
			lblInstructionsText = gamestate.Instance.getLangString ("gameInstructions");
		} else {
			lblInstructionsText = gamestate.Instance.getLangString ("sandboxInstructions");
		}
		lblInstructionsText = lblInstructionsText.Replace (" ", "    ");
		lblStart = gamestate.Instance.getLangString ("start");
		lblBackToMenu = gamestate.Instance.getLangString ("backToMenu");
	}

	// Our Startscreen GUI
	void OnGUI () 
	{
		int fontSize = (int)Math.Min((Screen.height / 600f) * 21f,(Screen.width / 600f) * 21f);

		buttonStyle = new GUIStyle(GUI.skin.button);
		buttonStyle.font = guiFont;
		buttonStyle.fontSize = fontSize;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		
		titleStyle = new GUIStyle(GUI.skin.label);
		titleStyle.font = titleFont;
		titleStyle.fontSize = fontSize*2;
		titleStyle.alignment = TextAnchor.MiddleCenter;
		
		subTitleStyle = new GUIStyle(GUI.skin.label);
		subTitleStyle.font = guiFont;
	    subTitleStyle.fontSize = fontSize;
		subTitleStyle.alignment = TextAnchor.MiddleCenter;

		textStyle = new GUIStyle(GUI.skin.label);
		textStyle.font = guiFont;
		textStyle.fontSize = (int)(fontSize/1.3f);
		textStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(0, fontSize*1, Screen.width, fontSize*4), lblAppName, titleStyle);
		GUI.Label(new Rect(0, fontSize*5, Screen.width, fontSize*2), lblInstructions, subTitleStyle);
		GUI.Label (new Rect (0, fontSize*7, Screen.width, fontSize*10), lblInstructionsText, textStyle);

		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*17, fontSize*10, fontSize*3), lblStart,buttonStyle))
		{
			startGame();
		}

		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*21, fontSize*10, fontSize*3), lblBackToMenu,buttonStyle))
		{
			gamestate.Instance.gotoGameStart();
		}

		
	}
	
	private void startGame()
	{
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startGame(gamestate.Instance.getDimension(), gamestate.Instance.isGame());
	}
	
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			gamestate.Instance.gotoGameStart();
		}
	}

}
