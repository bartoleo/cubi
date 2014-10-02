using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubi : MonoBehaviour
{
	private float screenWidth;
	private float screenHeight;
	private float ratio;

	private bool game;

	public GameObject cuboPrefab;
	public Camera camera;
	public float speed = 0.1F;
	private bool mobile = (Application.platform == RuntimePlatform.IPhonePlayer) || (Application.platform == RuntimePlatform.Android);
	Vector3 oldScreenPoint = Vector3.zero ;
	Vector3 startScreenPoint = Vector3.zero ;
	Vector2? startTouchPoint = Vector2.zero ;
	float? oldDistance = null;
	float? oldAngle = null;
	float minCameraz = 0;
	float startTime;

	GameObject first;
	GameObject second;
	GameObject[][][] grigliaCubi;


	void Start ()
	{
		GameObject cubo;

		screenWidth = Screen.width;
		screenHeight = Screen.height;
		ratio = screenWidth / screenHeight;

		int dimension = gamestate.Instance.getDimension ();
		game = gamestate.Instance.isGame ();

		grigliaCubi = new GameObject[dimension][][];

		for (int x = 1; x <= dimension; x++) {
			grigliaCubi[x-1] = new GameObject[dimension][];
			for (int y = 1; y <= dimension; y++) {
				grigliaCubi[x-1][y-1] = new GameObject[dimension];
				for (int z = 1; z <= dimension; z++) {

					float xpos = ((float)x-((float)dimension+1)/2);
					float ypos = ((float)y-((float)dimension+1)/2);
					float zpos = ((float)z-((float)dimension+1)/2);

					cubo = (GameObject)Instantiate (cuboPrefab, new Vector3 (xpos, ypos, zpos), Quaternion.identity);
					cubo.transform.parent = this.transform;
					grigliaCubi[x-1][y-1][z-1]=cubo;

				}
			}
		}

		if (game) {
			assignValuesToCubi();
		}

		minCameraz = (float)(-(float)dimension * 1.5);

		camera.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y, -8 - dimension*dimension/10);

		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update ()
	{

		/* TODO: normalizzare le dimensioni
		  var normalizedMousePos = Vector2(Input.mousePosition.x / screenWidth * ratio,
                                     Input.mousePosition.y / screenHeight);
        */
		if (mobile) {
			processTouch();
		} else {
			processMouse();
		}

	}

	void processTouch(){
		
		if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Began) {
			startTouchPoint = Input.GetTouch(0).position;
		} else if (Input.touchCount == 1 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			//transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			this.transform.RotateAround (this.transform.position, new Vector3 (0, 1, 0), -touchDeltaPosition.x );
			this.transform.RotateAround (this.transform.position, new Vector3 (1, 0, 0), touchDeltaPosition.y);
			oldDistance = null;
			oldAngle = null;
		} else if (Input.touchCount == 2) {
			
			Vector2 touch0, touch1;
			float? distance;
			float? angle;
			
			touch0 = Input.GetTouch(0).position;
			touch1 = Input.GetTouch(1).position;
			
			distance = Vector2.Distance(touch0, touch1);
			Vector2 v2 = touch0 - touch1;
			angle = Mathf.Atan2(v2.y, v2.x)*Mathf.Rad2Deg;
			
			if (oldDistance!=null){
				float diff = (float) ((distance-oldDistance)/30);
				if (camera.transform.position.z + diff < minCameraz){
					camera.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y, camera.transform.position.z + diff);
				}
			}
			if (oldAngle!=null){
				float diff = (float) (angle-oldAngle);
				
				this.transform.RotateAround(this.transform.position, new Vector3(0,0,1), diff);
			}
			
			oldDistance = distance;
			oldAngle = angle;
			
		} else if (Input.touchCount ==1 && Input.GetTouch (0).phase == TouchPhase.Ended) {
			float distanceFromTouch = Vector2.Distance((Vector2)startTouchPoint, Input.GetTouch(0).position);
			if (distanceFromTouch<30){
				RaycastHit hitInfo = new RaycastHit ();
				bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.GetTouch(0).position), out hitInfo);
				if (hit) {
					selectCube(hitInfo.transform);
				} 
				oldDistance = null;
				oldAngle = null;
				startTouchPoint = null;
			}
		} 
		
		if (Input.touchCount==0){
			oldDistance = null;
			oldAngle = null;
			startTouchPoint = null;
		}

	}

	void processMouse(){
		if (Input.GetMouseButton (0)) {
			
			Vector3 screenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);				
			if (oldScreenPoint != Vector3.zero) {
				this.transform.RotateAround (this.transform.position, new Vector3 (0, 1, 0), oldScreenPoint.x - screenPoint.x);
				this.transform.RotateAround (this.transform.position, new Vector3 (1, 0, 0), -oldScreenPoint.y + screenPoint.y);
			} else {
				startScreenPoint = screenPoint;
			}
			oldScreenPoint = screenPoint;
			
		} else {
			Vector3 screenPoint = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);				
			if (screenPoint == startScreenPoint && startScreenPoint != Vector3.zero) {
				RaycastHit hitInfo = new RaycastHit ();
				bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
				if (hit) {
					selectCube (hitInfo.transform);
				} 
			}
			oldScreenPoint = Vector3.zero;
			startScreenPoint = Vector3.zero;
		}
	}

	void selectCube(Transform cube){

		cubo cuboScript = cube.GetComponent<cubo>();

		if (game) {
			if (cuboScript.selected){
				cuboScript.seleziona(false);
				if (cube.gameObject == first){
					first = null;
				} else if (cube.gameObject == second){
					second = null;
				}  
			} else {
				cuboScript.seleziona(true);
				if (first==null){
					first = cube.gameObject;
				} else if (second==null){
					second = cube.gameObject;
				}
				if (first!=null&&second!=null&&first!=second){
					if (first.GetComponent<cubo>().value==second.GetComponent<cubo>().value){
						first = null;
						second = null;
						destroySelected();
						checkFinish();
					} else {
						first.GetComponent<cubo>().seleziona(false);
						second.GetComponent<cubo>().seleziona(false);
						first = null;
						second = null;
					}
				}
			}
		} else {
			cuboScript.selezionaSandbox();
		}

		/*
		for (int x=0; x<grigliaCubi.Length; x++) {
			for (int y=0; y<grigliaCubi.Length; y++) {
				for (int z=0; z<grigliaCubi.Length; z++) {
					if (grigliaCubi[x][y][z]!=null){
						if (grigliaCubi[x][y][z].transform == cube){
							print ("trovato:"+x+","+y+","+z);
						}
					}
				}
			}
		}*/

	}

	void OnGUI () 
	{
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
		myButtonStyle.fontSize = 21;

		GUIStyle timerLabelStyle = new GUIStyle(GUI.skin.label);
		timerLabelStyle.fontSize = 21;
		timerLabelStyle.alignment = TextAnchor.MiddleRight;

		if (!game) {
			if (GUI.Button (new Rect (10, 10, 200, 60), "Destroy Selected",myButtonStyle)) {
				destroySelected();
			}
		}

		GUI.color = Color.black;

		GUI.Label (new Rect (Screen.width - 200, 30, 170, 30), "Time: "+utility.getTimeMinutesSeconds(Time.time - startTime), timerLabelStyle);

	}

	void destroySelected(){
		for (int x=0; x<grigliaCubi.Length; x++) {
			for (int y=0; y<grigliaCubi.Length; y++) {
				for (int z=0; z<grigliaCubi.Length; z++) {
					if (grigliaCubi[x][y][z]!=null){
						if (grigliaCubi[x][y][z].GetComponent<cubo>().selected){
							Destroy(grigliaCubi[x][y][z]);
							grigliaCubi[x][y][z]=null;
						}
					}
				}
			}
		}
	}

	void assignValuesToCubi(){
		int size = 0;
		int index = 0;

		List<int> values = new List<int> ();

		for (int x=0; x<grigliaCubi.Length; x++) {
			for (int y=0; y<grigliaCubi.Length; y++) {
				for (int z=0; z<grigliaCubi.Length; z++) {
					if (grigliaCubi[x][y][z]!=null){
						size++;
					}
				}
			}
		}

		int colors = 9;
		float step = size;
		step = step / colors / 2f;
		print (step);
		step = Mathf.FloorToInt (step + 0.99f) * 2;
		if (step % 2 == 1) {
			step++;
		}
		print (step);
		int value;
		for (int i=0;i<size;i++){
			value = (int)(i/step);
			print (value);
			values.Add(value);
		}



		values = ShuffleList(values);

		index = 0;
		for (int x=0; x<grigliaCubi.Length; x++) {
			for (int y=0; y<grigliaCubi.Length; y++) {
				for (int z=0; z<grigliaCubi.Length; z++) {
					if (grigliaCubi[x][y][z]!=null){
						grigliaCubi[x][y][z].GetComponent<cubo>().value=values[index];
						grigliaCubi[x][y][z].GetComponent<cubo>().colora(false);
						index++;
					}
				}
			}
		}

	}

	private List<E> ShuffleList<E>(List<E> inputList)
	{
		List<E> randomList = new List<E>();
		
		int randomIndex = 0;
		while (inputList.Count > 0)
		{
			randomIndex = Random.Range(0, inputList.Count); //Choose a random object in the list
			randomList.Add(inputList[randomIndex]); //add it to the new, random list
			inputList.RemoveAt(randomIndex); //remove to avoid duplicates
		}
		
		return randomList; //return the new random list
	}

	void checkFinish(){
		int cubes = 0;
		for (int x=0; x<grigliaCubi.Length; x++) {
			for (int y=0; y<grigliaCubi.Length; y++) {
				for (int z=0; z<grigliaCubi.Length; z++) {
					if (grigliaCubi [x] [y] [z] != null) {
						cubes++;
					}
				}
			}
		}

		if (cubes <= 1) {
			gamestate.Instance.gamefinish(Time.time - startTime);
		}
	}

}
