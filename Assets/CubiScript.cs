using UnityEngine;
using System.Collections;

public class CubiScript : MonoBehaviour
{
	private float screenWidth;
	private float screenHeight;
	private float ratio;
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

	GameObject first;
	GameObject second;

	void Start ()
	{
		GameObject cubo;

		screenWidth = Screen.width;
		screenHeight = Screen.height;
		ratio = screenWidth / screenHeight;

		int dimension = gamestate.Instance.getDimension ();
		print (dimension);
		for (int y = 1; y <= dimension; y++) {
			for (int x = 1; x <= dimension; x++) {
				for (int z = 1; z <= dimension; z++) {

					float xpos = ((float)x-((float)dimension+1)/2);
					float ypos = ((float)y-((float)dimension+1)/2);
					float zpos = ((float)z-((float)dimension+1)/2);

					print(xpos +","+ ypos +","+ zpos);

					cubo = (GameObject)Instantiate (cuboPrefab, new Vector3 (xpos, ypos, zpos), Quaternion.identity);
					cubo.transform.parent = this.transform;
				}
			}
		}

		minCameraz = (float)(-(float)dimension * 1.5);

		camera.transform.position = new Vector3(camera.transform.position.x,camera.transform.position.y, -8 - dimension*dimension/10);


	}
	
	// Update is called once per frame
	void Update ()
	{

		/* TODO: normalizzare le dimensioni
		  var normalizedMousePos = Vector2(Input.mousePosition.x / screenWidth * ratio,
                                     Input.mousePosition.y / screenHeight);
        */
		if (mobile) {
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
				if (distanceFromTouch<20){
					RaycastHit hitInfo = new RaycastHit ();
					bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.GetTouch(0).position), out hitInfo);
					if (hit) {
						hitInfo.transform.GetComponent<CuboScript>().seleziona();
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

		} else {
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
				if (screenPoint == startScreenPoint) {
					RaycastHit hitInfo = new RaycastHit ();
					bool hit = Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hitInfo);
					if (hit) {
						hitInfo.transform.GetComponent<CuboScript>().seleziona();
					} 
				}
				oldScreenPoint = Vector3.zero;
				startScreenPoint = Vector3.zero;
			}
		}

	}
	
}
