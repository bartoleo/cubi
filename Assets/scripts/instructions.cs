using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {

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
		lblStart = gamestate.Instance.getLangString ("start");
		lblBackToMenu = gamestate.Instance.getLangString ("backToMenu");
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

		textStyle = new GUIStyle(GUI.skin.label);
		textStyle.fontSize = 15;
		textStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(Screen.width/2-200, 30, 400, 40), lblAppName, titleStyle);
		GUI.Label(new Rect(Screen.width/2-200, 70, 400, 40), lblInstructions, subTitleStyle);
		GUI.Label (new Rect (Screen.width / 2 - 200, 120, 400, 230), lblInstructionsText, textStyle);

		if(GUI.Button(new Rect (Screen.width/2-90, 350, 180, 60), lblStart,buttonStyle))
		{
			startGame();
		}

		if(GUI.Button(new Rect (Screen.width/2-90, 410, 180, 60), lblBackToMenu,buttonStyle))
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
