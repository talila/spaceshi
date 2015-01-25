using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	public Texture startScreen;

	public enum CameraMode {mixed, topdown, followbehind};
	public CameraMode camMode;
	[SerializeField]
	private Transform ship;
	[SerializeField]
	private float camSpeed = 2f;
	[SerializeField]
	private float maxTiltAngle = 40f;
	[SerializeField]
	private float minTiltAngle = 0f;
	[SerializeField]
	private float minAngleSpeed = 10f;
	[SerializeField]
	private float deadZoneVelocity = 3f;
	[SerializeField]
	private float sideAngle = 5f;

	private float tiltAngle;
	private Vector3 distanceVector;

	void Start () {
		if (deadZoneVelocity < 0)
		{
			deadZoneVelocity = -deadZoneVelocity;
		}
		distanceVector = Quaternion.Inverse(transform.rotation) * (transform.position - ship.position);
		maxTiltAngle = transform.rotation.eulerAngles.x;
		//transform.position = ship.position + transform.rotation * distanceVector;
		Time.timeScale = 0;
	}

	void Update() {
		if (Time.timeScale == 0 && Input.anyKey) {
			Time.timeScale = 1;
			audio.Play();
		}
	}
	
	void FixedUpdate () {
		if ((ship.rigidbody.velocity.magnitude > deadZoneVelocity || camMode == CameraMode.followbehind) && camMode != CameraMode.topdown)
		{
			tiltAngle = (minAngleSpeed - ship.rigidbody.velocity.magnitude - deadZoneVelocity) / (minAngleSpeed - deadZoneVelocity) * maxTiltAngle;
			tiltAngle = Mathf.Clamp(tiltAngle, minTiltAngle, maxTiltAngle);
			Vector3 desiredRotation = new Vector3(tiltAngle, (180 - ship.rotation.eulerAngles.y) - sideAngle, 0);
			Vector3 directionVector = desiredRotation - transform.rotation.eulerAngles;
			if(Mathf.Abs(directionVector.y) > 180) {
				directionVector.y = -Mathf.Sign(directionVector.y) * (360 - Mathf.Abs(directionVector.y));
			}
			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (directionVector) * camSpeed * Time.deltaTime);
			//transform.rotation = Quaternion.Euler(new Vector3(tiltAngle, ship.rotation.eulerAngles.y, 0));
			Vector3 desiredPosition = ship.position + transform.rotation * distanceVector;
			transform.position += (desiredPosition - transform.position) * camSpeed * Time.deltaTime;
			//transform.position = ship.position + transform.rotation * distanceVector;
		}
		else
		{
			Vector3 desiredPosition = ship.position + transform.rotation * distanceVector;
			transform.position += (desiredPosition - transform.position) * camSpeed * Time.deltaTime;
			//transform.position = ship.position + transform.rotation * distanceVector;
			Vector3 desiredRotation = new Vector3(maxTiltAngle, transform.rotation.eulerAngles.y, 0);
			transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (desiredRotation - transform.rotation.eulerAngles) * camSpeed * Time.deltaTime);
			//transform.rotation = Quaternion.Euler(new Vector3(90f, transform.rotation.eulerAngles.y, 0));
		}
	}

	void OnGUI() {
		if(Time.timeScale == 0) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), startScreen);
		}
	}
}
