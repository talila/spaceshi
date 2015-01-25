using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]

public class Asteroid : MonoBehaviour {
	
	public float speedFactor = 1.0f;

	private Vector3 rot;

	void Awake () {
		rot = RandomVector (speedFactor);
	}
	
	void FixedUpdate () {
		transform.Rotate (rot * 60 * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, transform.position.y % 2, transform.position.z); 
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "shot") {
			int count = transform.childCount;
			for(int i = count-1; i >= 0; i--) {
				Transform child = transform.GetChild(i);
				Rigidbody rig = child.gameObject.AddComponent<Rigidbody>();
				Asteroid a = child.gameObject.AddComponent<Asteroid>();
				rig.useGravity = false;
				rig.constraints = RigidbodyConstraints.FreezePositionY;
				rig.drag = 0.3f;
				a.addRandomForce(rig);
				child.collider.enabled = true;
				child.gameObject.layer = 10; //set layer to "asteroid"
				child.parent = null;
				child.position = new Vector3(child.position.x, 0, child.position.z);
			}
			collider.enabled = false;
			if(renderer) {
				renderer.enabled = false;
			}
			StartCoroutine("playDestroySound");
		}
	}

	private Vector3 RandomVector(float factor, bool y = true) {
		return new Vector3 (Mathf.Sign (Random.Range (-1, 2)) * Random.value * factor, (y ? Mathf.Sign (Random.Range (-1, 2)) * Random.value * factor : 0), Mathf.Sign (Random.Range (-1, 2)) * Random.value * factor);
	}

	public void addRandomForce(Rigidbody rig) {
		rig.AddForce(RandomVector(speedFactor * 100, false));
	}

	private IEnumerator playDestroySound() {
		audio.pitch = Random.Range (0.5f, 3.0f);
		audio.Play ();
		yield return new WaitForSeconds (audio.clip.length);
		Destroy (gameObject);
	}
}
