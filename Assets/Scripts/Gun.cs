using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

    public GameObject shot;

	public float recoil = 200.0f;

    public void Fire() {
		Quaternion rot = Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0);
        Instantiate(shot, transform.position, rot);
		transform.parent.rigidbody.AddRelativeForce (transform.localRotation * new Vector3(0, recoil, 0));
    }
}
