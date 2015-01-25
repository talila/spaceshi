using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	[SerializeField]
	private float rotationSpeed = 30f;
	[SerializeField]
	private float throttle = 60f;
	[SerializeField]
	private float maxAngleIn = 45f;
	[SerializeField]
	private float maxAngleOut = 135f;

	[SerializeField]
	private Transform controller1;
	[SerializeField]
	private bool invert1 = false;
	[SerializeField]
	private Transform controller2;
	[SerializeField]
	private bool invert2 = false;
	[SerializeField]
	private Transform controller3;
	[SerializeField]
	private bool invert3 = false;
	[SerializeField]
	private Transform controller4;
	[SerializeField]
	private bool invert4 = false;
	
	void Update () {

		if (controller1.tag == "engine")
		{
			controller1.parent.rigidbody.AddRelativeForce(controller1.localRotation * new Vector3(0, Input.GetButton("Action1") ? -throttle * Time.deltaTime : 0, 0));
			if (Input.GetButtonDown("Action1") && !controller1.audio.isPlaying)
			{
				controller1.audio.Play();
				StartParticles(controller1);
			}
			if (Input.GetButtonUp("Action1"))
			{
				controller1.audio.Stop();
				StartParticles(controller1, false);
			}
		}
		else
		{
			if (Input.GetButtonDown("Action1"))
			{
				controller1.gameObject.GetComponent<Gun>().Fire();
				controller1.audio.Play();
			}
		}
		if (controller2.tag == "engine") {
			controller2.parent.rigidbody.AddRelativeForce(controller2.localRotation * new Vector3(0, Input.GetButton("Action2") ? -throttle * Time.deltaTime : 0, 0));
			if (Input.GetButtonDown("Action2") && !controller2.audio.isPlaying)
			{
				controller2.audio.Play();
				StartParticles(controller2);
			}
			if (Input.GetButtonUp("Action2"))
			{
				controller2.audio.Stop();
				StartParticles(controller2, false);
			}
		}
		else
		{
			if (Input.GetButtonDown("Action2"))
			{
				controller2.gameObject.GetComponent<Gun>().Fire();
				controller2.audio.Play();
			}
		}
		if (controller3.tag == "engine") {
			controller3.parent.rigidbody.AddRelativeForce(controller3.localRotation * new Vector3(0, Input.GetButton("Action3") ? -throttle * Time.deltaTime : 0, 0));
			if (Input.GetButtonDown("Action3") && !controller3.audio.isPlaying)
			{
				controller3.audio.Play();
				StartParticles(controller3);
			}
			if (Input.GetButtonUp("Action3"))
			{
				controller3.audio.Stop();
				StartParticles(controller3, false);
			}
		}
		else
		{
			if (Input.GetButtonDown("Action3"))
			{
				controller3.gameObject.GetComponent<Gun>().Fire();
				controller3.audio.Play();
			}
		}
		if (controller4.tag == "engine") {
			controller4.parent.rigidbody.AddRelativeForce(controller4.localRotation * new Vector3(0, Input.GetButton("Action4") ? -throttle * Time.deltaTime : 0, 0));
			if (Input.GetButtonDown("Action4") && !controller4.audio.isPlaying)
			{
				controller4.audio.Play();
				StartParticles(controller4);
			}
			if (Input.GetButtonUp("Action4"))
			{
				controller4.audio.Stop();
				StartParticles(controller4, false);
			}
		}
		else
		{
			if (Input.GetButtonDown("Action4"))
			{
				controller4.gameObject.GetComponent<Gun>().Fire();
				controller4.audio.Play();
			}
		}

		if (!rotateLimitsReached(controller1))
		{
			controller1.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal1") * rotationSpeed * Time.deltaTime * (invert1 ? 1 : -1)));
		}
		if (!rotateLimitsReached(controller2))
		{
			controller2.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal2") * rotationSpeed * Time.deltaTime * (invert2 ? 1 : -1)));
		}
		if (!rotateLimitsReached(controller3))
		{
			controller3.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal3") * rotationSpeed * Time.deltaTime * (invert3 ? 1 : -1)));
		}
		if (!rotateLimitsReached(controller4))
		{
			controller4.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal4") * rotationSpeed * Time.deltaTime * (invert4 ? 1 : -1)));
		}
	}

	private void StartParticles(Transform t, bool enable = true)
	{
		//if (enable)
		//{
			t.GetComponentInChildren<ParticleSystem>().enableEmission = enable;
		//}
		//else
		//{
		//	t.GetComponentInChildren<ParticleSystem>().Pause();
		//}
	}

	private bool rotateLimitsReached(Transform t) {
		float angle;
		if (t.localRotation.eulerAngles.z > 180)
		{
			angle = t.localRotation.eulerAngles.z - 360;
		}
		else
		{
			angle = t.localRotation.eulerAngles.z;
		}
		
		float angleIn;
		float angleOut;
		if (t.parent.localPosition.x < 0)
		{
			angleIn = -maxAngleIn;
			angleOut = maxAngleOut;
			if (angle < angleIn || angle > angleOut)
			{
				t.localRotation = Quaternion.Euler(new Vector3(0, 0, angle < angleIn ? angleIn + 0.001f : angleOut - 0.001f));
				return true;
			}
			else {
				return false;
			}
		}
		else
		{
			angleIn = maxAngleIn;
			angleOut = -maxAngleOut;
			if (angle > angleIn || angle < angleOut)
			{
				t.localRotation = Quaternion.Euler(new Vector3(0, 0, angle > angleIn - 0.001f ? angleIn - 0.001f : angleOut + 0.001f));
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
