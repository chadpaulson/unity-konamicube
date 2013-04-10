using UnityEngine;
using System.Collections;

public class GameCube : MonoBehaviour {
	
	public float range;
	private ParticleSystem particleSystem;
	private TrailRenderer trailRenderer;
	
	void Start () {
		
		// disable particle emitter
		particleSystem = gameObject.GetComponent<ParticleSystem>();
		particleSystem.enableEmission = false;
		particleSystem.Stop();
		
		// disable trail renderer
		trailRenderer = gameObject.GetComponent<TrailRenderer>();
		trailRenderer.enabled = false;
		
	}
	
	void Update () {
	
		// position based on left analog stick input
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float xPos = h * range;
		float yPos = v * range;
		transform.position = new Vector3(xPos, yPos, 0);
		
		// toggle particle emitter
		if(Input.GetButtonUp("L2")) {
			particleSystem.enableEmission = !particleSystem.enableEmission;
			if(particleSystem.enableEmission){
				particleSystem.Play();
			} else {
				particleSystem.Stop();
			}
		}
		
		// toggle trail renderer
		if(Input.GetButtonUp("R2")) {
			trailRenderer.enabled = !trailRenderer.enabled;
		}
		
	}
}
