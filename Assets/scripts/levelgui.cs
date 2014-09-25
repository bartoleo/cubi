using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {
	
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
		GUI.Label(new Rect(30, 100, 400, 30), "Level: " + gamestate.Instance.getLevel());
	
	}

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) { 
			Application.LoadLevel("gamestart");
		}
	}
}