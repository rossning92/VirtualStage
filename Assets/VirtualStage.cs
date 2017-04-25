using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualStage : MonoBehaviour {

	public Camera handheldCamera;
	public Camera hmdCamera;


	// Use this for initialization
	void Start () {

		GameObject controller = GameObject.Find ("Controller (left)");

		if (handheldCamera == null)
			handheldCamera = GameObject.Find ("Camera (eye)").GetComponent<Camera>();

		if (hmdCamera == null)
			handheldCamera = GameObject.Find ("HmdCamera").GetComponent<Camera>();


		// Attach the camera it to the controller
		handheldCamera.transform.SetParent (controller.transform);


		// Disable handheld camera by default
		handheldCamera.enabled = false;
		handheldCamera.stereoTargetEye = StereoTargetEyeMask.None;
	}

	private void SwitchToHeadsetCamera() {
		handheldCamera.enabled = false;
	}

	private void SwitchToControllerCamera() {
		handheldCamera.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
