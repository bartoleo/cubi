using UnityEngine;
using System.Collections;
using System.IO;

public class gamestate : MonoBehaviour {
	
	// Declare properties
	private static gamestate instance;

	private string activeLevel;			// Active level
	private int dimension;
	private bool game;
	private bool win;
	private float time; 

	private string currentLang;

	private Lang lang;

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

	public bool isWin()
	{
		return win;
	}
	public void setwin(bool newWin)
	{
		win = newWin;
	}

	public float getTime()
	{
		return time;
	}
	public void setTime(float newTime)
	{
		time = newTime;
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
				instance.game = true;
				instance.currentLang = Application.systemLanguage.ToString();

				instance.lang = new Lang("language", instance.currentLang);

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
	// openInstructions()
	// --------------------------------------------------------------------------------------------------- 
	// Opens instructions
	// ---------------------------------------------------------------------------------------------------
	public void openInstructions(int newDimension, bool newGame)
	{
		activeLevel = "Level "+newDimension;
		dimension = newDimension;
		game = newGame;
		Application.LoadLevel("instructions");
	}

	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startGame(int newDimension, bool newGame)
	{
		activeLevel = "Level "+newDimension;
		dimension = newDimension;
		game = newGame;
		Application.LoadLevel("game01");
	}

	// ---------------------------------------------------------------------------------------------------
	// gotoGameStart()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void gotoGameStart()
	{
		Application.LoadLevel("gamestart");
	}

	// ---------------------------------------------------------------------------------------------------
	// gotoGameStart()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void gamefinish(float time)
	{
		gamestate.Instance.setTime (time);
		Application.LoadLevel("gamefinish");
	}

	public string getLangString(string key){
		return gamestate.instance.lang.getString (key);
	}

}