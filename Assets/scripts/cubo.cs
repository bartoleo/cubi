using UnityEngine;
using System.Collections;

public class cubo : MonoBehaviour {

	public bool selected;
	public int value;
	private Color[] colors =  new Color[9]{ 
		new Color (1, 0, 0),
		new Color (0, 0.6f, 0), 
		new Color (0, 0, 1),
		new Color (1, 1, 0),
		new Color (0, 1, 1),
		new Color (1, 0, 1),
		new Color (0.6f, 0.6f, 0.6f),
		new Color (1f, 0.6f, 0.2f),
		new Color (0.2f, 0.2f, 0.2f)};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void colora (bool pSelected){
		Color color = colors [value];
		if (pSelected) {
			color = color*2;
		}
		this.GetComponent<Renderer>().material.color = color;
	}

	public void seleziona(bool pSelected){
		selected = pSelected;
		colora (selected);
	}

	public void selezionaSandbox(){
		selected = !selected;
		if (selected) {
			this.GetComponent<Renderer>().material.color = new Color (1, 0, 0); 
		} else {
			this.GetComponent<Renderer>().material.color = new Color (1, 1, 1); 
		}
	}

}
