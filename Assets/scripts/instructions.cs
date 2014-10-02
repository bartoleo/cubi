using UnityEngine;
using System.Collections;

public class instructions : MonoBehaviour {

	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;
	private GUIStyle textStyle;
	
	private int dimension = 5;
	// Use this for initialization
	void Start () {
	
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

		GUI.Label(new Rect(Screen.width/2-200, 30, 400, 40), "CUBI", titleStyle);
		GUI.Label(new Rect(Screen.width/2-200, 70, 400, 40), "Instructions", subTitleStyle);

		if (gamestate.Instance.isGame ()) {
			GUI.Label (new Rect (Screen.width / 2 - 200, 120, 400, 230), "Match two cubes by color to destroy them.\n\nYou can rotate & pinch.\n\nEnjoy!", textStyle);
		} else {
			GUI.Label (new Rect (Screen.width / 2 - 200, 120, 400, 230), "Select cubes by touch.\n\nDestroy selected cubes with 'Destroy Selected'\n\nYou can rotate & pinch.\n\nEnjoy!", textStyle);
		}

		if(GUI.Button(new Rect (Screen.width/2-90, 350, 180, 60), "Start",buttonStyle))
		{
			startGame();
		}

		if(GUI.Button(new Rect (Screen.width/2-90, 410, 180, 60), "Back to Menu",buttonStyle))
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
