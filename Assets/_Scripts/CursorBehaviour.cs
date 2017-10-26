using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorBehaviour : MonoBehaviour {

	public Camera cam;
	RaycastHit hit;
	public Image gaze;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 100)){
//			Debug.Log(hit.collider.name);
			if (hit.collider.gameObject.tag == "Point") {
				Grow temp = hit.collider.gameObject.GetComponent<Grow>();
				temp.canGrow = true;
			}
			if ((hit.collider.gameObject.tag == "Point") && (gaze.fillAmount <= 1)) {
				gaze.fillAmount += 0.03f;
			} else {
				gaze.fillAmount -= 0.03f;
			}
			if (gaze.fillAmount > 0.99f) {
				Vector3 newPos = hit.collider.transform.position;
				Debug.Log (hit.collider.transform.position);
				transform.position = new Vector3(newPos.x, 0, newPos.z);
				transform.rotation = hit.collider.transform.rotation;
			}
		}
	}



}
