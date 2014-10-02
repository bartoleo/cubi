using UnityEngine;
using System.Collections;

public class utility {
	public static string getTimeMinutesSeconds(float timer){
		string minutes = Mathf.Floor(timer / 60).ToString("00");
		string seconds = Mathf.Floor(timer % 60).ToString("00");
		return minutes + "." + seconds;
	}
}