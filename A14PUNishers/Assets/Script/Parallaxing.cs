using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;		//All backgrounds and foregrounds to be parallaxed
	private float[] parallaxScales;		//Proportions of camera's movement to move backgrounds by
	public float smoothing = 1f;		//How smooth the parallax is (must be over 0)

	private Transform cam;				//Reference to MainCamera's transfrom
	private Vector3 previousCamPos;		//Position of camera in previous frame

	// Is called before Start. Used for references.
	void Awake() {
		//set reference to camera
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;

		parallaxScales = new float[backgrounds.Length];

		//Assigning corresponding parallaxScales
		for(int i = 0; i < backgrounds.Length; i++){
			parallaxScales[i] = backgrounds[i].position.z*-1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < backgrounds.Length; i++){
			//Parallax is opposite of camera movement because previous frame multiplied by scale
			float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

			//Set target X position which is the current position + parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create target position which is the backgound's current position with it's target x position
			Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
		
			//fade between current and target position
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing*Time.deltaTime);
		}

		//set previousCamPos to the camera's position at the end of frame
		previousCamPos = cam.position;
	}
}
