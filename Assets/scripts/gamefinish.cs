using UnityEngine;
using System.Collections;

public class gamefinish : MonoBehaviour {

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

		GUI.Label(new Rect(Screen.width/2-240, 30, 480, 60), "CONGRATULATIONS!!!", titleStyle);
		GUI.Label(new Rect(Screen.width/2-240, 80, 480, 60), "Your time is "+utility.getTimeMinutesSeconds(gamestate.Instance.getTime()), subTitleStyle);
		
		if(GUI.Button(new Rect (Screen.width/2-90, 350, 180, 60), "Back to Menu",buttonStyle))
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
