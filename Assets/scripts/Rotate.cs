using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

void Start () {

}
	Touch t;
	float moveSpeed = 2.0f;

void Update ()
{
    if (Input.touches.Length > 0) {
         t = Input.GetTouch (0);

        if (t.phase == TouchPhase.Moved) {
            var delta = t.deltaPosition * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, Mathf.Atan2 (delta .y, delta.x) * Mathf.Rad2Deg));
        }
    }
}
}