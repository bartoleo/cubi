using UnityEngine;
using System.Collections;
using System;

public class gamefinish : MonoBehaviour {

	public Font guiFont;
	public Font titleFont;
	
	private GUIStyle buttonStyle;
	private GUIStyle titleStyle;
	private GUIStyle subTitleStyle;
	private GUIStyle textStyle;

	private string lblCongratulations;
	private string lblYourTimeIs;
	private string lblBackToMenu;

	private int dimension = 5;
	// Use this for initialization
	void Start () {
	
	}

	void OnEnable() {
		lblCongratulations = gamestate.Instance.getLangString ("congratulations");
		lblYourTimeIs = gamestate.Instance.getLangString ("yourTimeIs");
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
		titleStyle.fontSize = (int)(fontSize*1.5);
		titleStyle.alignment = TextAnchor.MiddleCenter;

		subTitleStyle = new GUIStyle(GUI.skin.label);
		subTitleStyle.font = guiFont;
		subTitleStyle.fontSize = fontSize;
		subTitleStyle.alignment = TextAnchor.MiddleCenter;

		GUI.Label(new Rect(0, fontSize*1 , Screen.width, fontSize*4), lblCongratulations, titleStyle);
		GUI.Label(new Rect(0, fontSize*7 , Screen.width, fontSize*4), lblYourTimeIs+utility.getTimeMinutesSeconds(gamestate.Instance.getTime()), subTitleStyle);
		
		if(GUI.Button(new Rect (Screen.width/2-fontSize*5, fontSize*21, fontSize*10, fontSize*3), lblBackToMenu,buttonStyle))
		{
			gamestate.Instance.gotoGameStart();
		}

		
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			gamestate.Instance.gotoGameStart();
		}
	}

}
