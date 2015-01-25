using UnityEngine;
using System.Collections;

public class WoWCamera : MonoBehaviour {

	//public Transform Target {
	//  set;
	//  get;
	//}

    public float targetHeight = 3.0f;
    public float distance = 10.0f;
    public float distanceOnNitro = 12.0f;
    public float heightRotation = 10.0f;
    public float rotationDampening = 3.0f;
    public bool stopCameraMovement = false;
    public float currentDistance = 0;

    //private float targetHeight = 0.0f;
    //private float distance = 0.0f;
    //private float distanceOnNitro = 12.0f;
    //private float heightRotation = 10.0f;
    //private float rotationDampening = 3.0f;
    //private bool stopCameraMovement = false;
    //private float currentDistance = 0;

    //private QualityLevel qualitySettings = QualityLevel.Simple;

    //private Camera wowCamera = null;

    public Transform target = null;
    //private bool nitroCameraOn = false;
    //private float fieldOfViewAddNitroMax = 15f;
    //private float fieldOfViewSteps = 0.2f;
    //private float fieldOfViewDefault = 55f;

  private float cameraMovementSpeedOnNitro = 0.1f;

    public bool CameraOnNitro {
      get;
      set;
    }
  
    void Start() {
      currentDistance = distance;
      //wowCamera = this.GetComponent<Camera>();
      //SetQualitySettings();
      //qualitySettings = QualitySettings.currentLevel;
      //Target = GameObject.Find("main_traktor").transform;
    }


    void Update() {

      //SetQualitySettings();
    }

    //private void SetQualitySettings() {
    //  if (qualitySettings != QualitySettings.currentLevel) {
    //    if (QualitySettings.currentLevel == QualityLevel.Fantastic) {
    //      this.camera.nearClipPlane = 1;
    //      this.camera.farClipPlane = 900;
    //    }
    //    else if (QualitySettings.currentLevel == QualityLevel.Good) {
    //      this.camera.nearClipPlane = 1;
    //      this.camera.farClipPlane = 600;
    //    }
    //    else if (QualitySettings.currentLevel == QualityLevel.Fastest) {
    //      this.camera.nearClipPlane = 1;
    //      this.camera.farClipPlane = 300;
    //    }
    //    qualitySettings = QualitySettings.currentLevel;
    //  }
    //}
    
    //@script AddComponentMenu("Camera-Control/WoW Camera")
    //float test = 0;
    private void FixedUpdate ()
    {
	  //if (Target == null) {
	  //  //GameObject go = GameObject.Find("enemies/enemy_1");//main_traktor");
	  //  GameObject go = GameObject.Find("main_traktor");
	  //  if (go != null) {
	  //	Target = go.transform;
	  //  }
	  //}
	  //else {
       // if (EndSequence.endSequenceRunning == false) {
       //   if (stopCameraMovement == false) {
            if (target != null) {
				float y = Mathf.LerpAngle(transform.eulerAngles.y, target.eulerAngles.y, rotationDampening * Time.deltaTime);
				float x = Mathf.LerpAngle(transform.eulerAngles.x, target.eulerAngles.x + heightRotation, rotationDampening * Time.deltaTime);
              transform.rotation = Quaternion.Euler(x, y, 0);
              if (this.CameraOnNitro) {
                if (this.distanceOnNitro > currentDistance) {
                  currentDistance += cameraMovementSpeedOnNitro;
                }
				transform.position = target.position - (transform.rotation * Vector3.forward * this.currentDistance + new Vector3(0, -targetHeight, 0));
              }
              else {
                if (this.distance <= currentDistance) {
                  currentDistance -= cameraMovementSpeedOnNitro;
                }
				transform.position = target.position - (transform.rotation * Vector3.forward * currentDistance + new Vector3(0, -targetHeight, 0));
              }
            }
       //   }
	  //  }
	  //  else {
	  //	test += 1f;
	  //	float y = test;
	  //	//float x = Mathf.LerpAngle(transform.eulerAngles.x, Target.eulerAngles.x + heightRotation, rotationDampening * Time.deltaTime);
	  //	transform.rotation = Quaternion.Euler(0, y, 0);
          
	  //	transform.position = Target.position - (transform.rotation * Vector3.forward * currentDistance + new Vector3(0, -targetHeight-4f, 0));
	  //	this.transform.LookAt(Target);
	  //  }
	  //}

      
	  //if (target == null) {
	  //  Transform gomt = this.transform.parent.parent.FindChild("main_traktor");
	  //  target = gomt.GetComponent<Driving>();
	  // // mainTraktor.SetReferenceToWoWCamera(this);
	  //}

	  //if (target != null) {
	  //  nitroCameraOn = target.NitroButtonPressed;
	  //  if (nitroCameraOn) {
	  //	float fieldOfViewNitroMax = (fieldOfViewAddNitroMax * target.GetSpeedPercent()) + this.fieldOfViewDefault;
	  //	if (this.wowCamera.fieldOfView < fieldOfViewNitroMax) {
	  //	  this.wowCamera.fieldOfView += fieldOfViewSteps;
	  //	}
	  //  }
	  //  else {
	  //	if (this.wowCamera.fieldOfView > this.fieldOfViewDefault) {
	  //	  this.wowCamera.fieldOfView -= fieldOfViewSteps;
	  //	}
	  //  }
	  //}
    }

  //public Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle) {
  //   Vector3 finalPos = point - pivot;
  //   //Center the point around the origin
  //   finalPos = angle * finalPos;
  //   //Rotate the point.

  //   finalPos += pivot;
  //   //Move the point back to its original offset. 

  //   return finalPos;
  //}
}