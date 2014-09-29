using UnityEngine;
using System.Collections;

public class cubo : MonoBehaviour {

	public bool selected;
	public int value;
	private Color[] colors =  new Color[4]{ new Color (1, 0, 0),new Color (0, 0, 1),new Color (0, 0.6f, 0), new Color (1, 1, 0)};

	// Use this for initialization
	void Start () {
		colors = new Color[4];
		colors [0] = new Color (1, 0, 0);
		colors [1] = new Color (0, 0, 1);
		colors [2] = new Color (0, 0.8f, 0);
		colors [3] = new Color (1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void colora (bool pSelected){
		print (this.renderer.material.color);
		print (colors [value]);
		this.renderer.material.color = colors[value];
	}

	public void seleziona(){
		selected = !selected;
		colora (selected);
	}

	public void selezionaSandbox(){
		selected = !selected;
		if (selected) {
			this.renderer.material.color = new Color (1, 0, 0); 
		} else {
			this.renderer.material.color = new Color (1, 1, 1); 
		}
	}

}
