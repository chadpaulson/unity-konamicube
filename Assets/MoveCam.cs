using UnityEngine;
using System.Collections;

public class MoveCam : MonoBehaviour {
	
	public float range;
	private GameObject cube;
	
	void Start () {
		
		// define cube
		cube = GameObject.Find("Cube");
		
	}
	
	void Update () {
	
		// position based on right analog stick input
		float h = Input.GetAxis("hCam");
		float v = Input.GetAxis("vCam");
		float xPos = h * range;
		float yPos = v * range;
		transform.position = new Vector3(xPos, yPos, transform.position.z);
		transform.LookAt(cube.transform);
		
				
		// zoom out
		if(Input.GetButton("L1")){
			if(transform.camera.fieldOfView < 170){
				transform.camera.fieldOfView += 5;
			}
		}
		
		// zoom in
		if(Input.GetButton("R1")){
			if(transform.camera.fieldOfView > 10){
				transform.camera.fieldOfView -=5;	
			}
		}
		
		
	}
}
