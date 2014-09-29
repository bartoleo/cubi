using UnityEngine;
using System.Collections;

public class gamestate : MonoBehaviour {
	
	// Declare properties
	private static gamestate instance;

	private string activeLevel;			// Active level
	private int dimension;
	private bool game;

	public string getLevel()
	{
		return activeLevel;
	}
	public void setLevel(string newLevel)
	{
		activeLevel = newLevel;
	}

	public int getDimension()
	{
		return dimension;
	}
	public void setDimension(int newDimension)
	{
		dimension = newDimension;
	}

	public bool isGame()
	{
		return game;
	}
	public void setGame(bool newGame)
	{
		game = newGame;
	}
	
	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = ((GameObject) new GameObject("gamestate")).AddComponent<gamestate>();

				instance.dimension = 5;

			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState(int newDimension, bool newGame)
	{
		print ("Creating a new game state");
		activeLevel = "Level "+newDimension;
		dimension = newDimension;
		game = newGame;
		Application.LoadLevel("game01");
	}
}