using UnityEngine;
using System.Collections;

public class DualShock : MonoBehaviour {
	
	private ArrayList buttonsPressed = new ArrayList();
	private AudioSource contra;
	private GameObject plane;
	private GameObject cube;
	private GameObject pointLight;
	private Camera mainCamera;
	
	public float smooth;
	
	
	void Start () {
		
		// assign initial plane color
		plane = GameObject.Find("Plane");
		plane.renderer.material.color = getRandColor();
		
		// assign initial camera background color
		mainCamera = GameObject.Find("Camera").camera;
		mainCamera.backgroundColor = getRandColor();
		
		// assign initial cube color
		cube = GameObject.Find("Cube");
		cube.renderer.material.color = getRandColor();
		
		// define point light
		pointLight = GameObject.Find("Light");
		
		// define our audio source
		contra = GetComponent<AudioSource>();
		
		// can be changed in the inspector at runtime
		smooth = 133.4f;
		
	}
	

	void Update () {
		
		if(Input.GetButtonDown("X")) {
			buttonsPressed.Add("X");
			Debug.Log ("X was pressed");
		}
		
		if(Input.GetButtonDown("Square")){
			buttonsPressed.Add("Square");
			Debug.Log ("Square was pressed");
		}
		
		if(Input.GetButtonDown("Circle")){
			buttonsPressed.Add("Circle");
			Debug.Log ("Circle was pressed");
		}
		
		if(Input.GetButtonDown("Triangle")){
			buttonsPressed.Add("Triangle");
			Debug.Log ("Triangle was pressed");
		}
		
		if(Input.GetButtonDown("Up")){
			buttonsPressed.Add("Up");
			Debug.Log ("Up was pressed");
		}
		
		if(Input.GetButtonDown("Down")){
			buttonsPressed.Add("Down");
			Debug.Log ("Down was pressed");
		}
		
		if(Input.GetButtonDown("Left")){
			buttonsPressed.Add("Left");
			Debug.Log ("Left was pressed");
		}
		
		if(Input.GetButtonDown("Right")){
			buttonsPressed.Add("Right");
			Debug.Log ("Right was pressed");
		}
		
		if(Input.GetButtonDown("Select")){
			buttonsPressed.Add("Select");
			Debug.Log ("Select was pressed");
		}
		
		if(Input.GetButtonDown ("Start")){
			buttonsPressed.Add("Start");
			Debug.Log ("Start was pressed");
		}
		
		if(Input.GetButtonDown("L1")){
			buttonsPressed.Add("L1");
			Debug.Log ("L1 was pressed");
		}
		
		if(Input.GetButtonDown("L2")){
			buttonsPressed.Add("L2");
			Debug.Log ("L2 was pressed");
		}
		
		if(Input.GetButtonDown("L3")){
			buttonsPressed.Add("L3");
			Debug.Log ("L3 was pressed");
		}
		
		if(Input.GetButtonDown("R1")){
			buttonsPressed.Add("R1");
			Debug.Log ("R1 was pressed");
		}
		
		if(Input.GetButtonDown("R2")){
			buttonsPressed.Add("R2");
			Debug.Log ("R2 was pressed");
		}
		
		if(Input.GetButtonDown("R3")){
			buttonsPressed.Add("R3");
			Debug.Log ("R3 was pressed");
		}
		
		
		VerifyKonamiCode();
		
		
		
		/* Handle Color LERPs */
		
		// change cube color
		if(Input.GetButton("Square")){
			cube.renderer.material.color = Color.Lerp(this.cube.renderer.material.color, getRandColor(), smooth * Time.deltaTime);
		}
		
		// change camera background color
		if(Input.GetButton("Triangle")){
			mainCamera.backgroundColor = Color.Lerp(this.mainCamera.backgroundColor, getRandColor(), smooth * Time.deltaTime);
		}
		
		// change plane color
		if(Input.GetButton("X")){
			plane.renderer.material.color = Color.Lerp(this.plane.renderer.material.color, getRandColor(), smooth * Time.deltaTime);
		}
		
		// change light color
		if(Input.GetButton("Circle")){
			pointLight.light.color = Color.Lerp(this.pointLight.light.color, getRandColor(), smooth * Time.deltaTime);
		}
		
	}
	
	void VerifyKonamiCode() {
	
		int buttonCount = buttonsPressed.Count;
		
		if(buttonCount >= 10) {
			
			if(buttonsPressed[buttonCount-1] == "Circle" && buttonsPressed[buttonCount-2] == "X" &&
				buttonsPressed[buttonCount-3] == "Right" && buttonsPressed[buttonCount-4] == "Left" &&
				buttonsPressed[buttonCount-5] == "Right" && buttonsPressed[buttonCount-6] == "Left" &&
				buttonsPressed[buttonCount-7] == "Down" && buttonsPressed[buttonCount-8] == "Down" &&
				buttonsPressed[buttonCount-9] == "Up" && buttonsPressed[buttonCount-10] == "Up"){
				
				Debug.Log("Konami Code!");
				
				buttonsPressed.Clear();
				contra.Play();
				
			}
						
		}
		
	}
	
	
	Color getRandColor(){
	
		return new Color(Random.value, Random.value, Random.value);
		
	}
	
}
