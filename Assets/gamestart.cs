using UnityEngine;
using System.Collections;

public class gamestart : MonoBehaviour {

	
	// Our Startscreen GUI
	void OnGUI () 
	{
		
		if(GUI.Button(new Rect (30, 30, 150, 30), "Start Game 2"))
		{
			startGame(2);
		}
		if(GUI.Button(new Rect (30, 60, 150, 30), "Start Game 3"))
		{
			startGame(3);
		}
		if(GUI.Button(new Rect (30, 90, 150, 30), "Start Game 4"))
		{
			startGame(4);
		}
		if(GUI.Button(new Rect (30, 120, 150, 30), "Start Game 5"))
		{
			startGame(5);
		}
		if(GUI.Button(new Rect (30, 150, 150, 30), "Start Game 7"))
		{
			startGame(7);
		}
		if(GUI.Button(new Rect (30, 180, 150, 30), "Start Game 9"))
		{
			startGame(9);
		}
		if(GUI.Button(new Rect (30, 210, 150, 30), "Start Game 20"))
		{
			startGame(20);
		}
		if(GUI.Button(new Rect (30, 270, 150, 30), "Quit"))
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
