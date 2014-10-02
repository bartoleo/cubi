using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {

	GUIStyle labelStyle;

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + gamestate.Instance.getLevel());
	}
	
	
	
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// --------------------------------------------------------------------------------------------------- 
	// Provides a GUI on level scenes
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{				
		labelStyle = new GUIStyle(GUI.skin.label);
		labelStyle.fontSize = 21	;
		labelStyle.alignment = TextAnchor.MiddleCenter;

		GUI.color = Color.black;

		GUI.Label(new Rect(Screen.width/2-200, 30, 400, 30), gamestate.Instance.getLevel(), labelStyle);
	
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			gamestate.Instance.gotoGameStart();
		}
	}
}