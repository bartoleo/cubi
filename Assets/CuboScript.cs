using UnityEngine;
using System.Collections;

public class CuboScript : MonoBehaviour {

	public bool selected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void seleziona(){
		selected = !selected;
		print (selected);
		if (selected) {
			this.renderer.material.color = new Color (1, 0, 0); 
		} else {
			this.renderer.material.color = new Color (1, 1, 1); 
		}


	}
}
