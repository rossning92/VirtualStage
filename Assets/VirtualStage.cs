using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VirtualStage : MonoBehaviour {

	public Camera handheldCamera;
	public Camera hmdCamera;


	// Use this for initialization
	void Start () {



		if (handheldCamera == null)
			handheldCamera = GameObject.Find ("HandheldCamera").GetComponent<Camera>();

		if (hmdCamera == null)
			hmdCamera = GameObject.Find ("Camera (eye)").GetComponent<Camera>();


		// Disable handheld camera by default
		handheldCamera.enabled = false;
		handheldCamera.stereoTargetEye = StereoTargetEyeMask.None;


	}

	private void SwitchToHmdCamera() {
		handheldCamera.enabled = false;
	}

	private void SwitchToHandheldCamera() {
		handheldCamera.enabled = true;
	}

	void SwitchCamera ()
	{
		if (handheldCamera.enabled) {
			SwitchToHmdCamera ();
			Debug.Log ("Switched to HMD camera.");
		}
		else {
			SwitchToHandheldCamera ();
			Debug.Log ("Switched to handheld camera.");
		}
	}
	
	// Update is called once per frame
	void Update () {

		bool controllerTriggered = SteamVR_Controller.Input (0).GetPressDown (EVRButtonId.k_EButton_Axis1);
		bool keyPressed = Input.GetKeyDown (KeyCode.S);

		if (controllerTriggered || keyPressed) {

			SwitchCamera ();

		}



		// Attach the handheld camera it to the first controller
		GameObject controller = GameObject.Find ("Controller (left)");
		if (controller != null) {
			handheldCamera.transform.SetParent (controller.transform);
			handheldCamera.transform.localPosition = new Vector3 ();
		}

	}
}
