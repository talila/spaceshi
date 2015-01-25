using UnityEngine;
using System.Collections;

public class ShitCollisions : MonoBehaviour {

    public GameObject ship;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionEnter(Collision collision) {
        Debug.Log("shit collision");
        if (collision.gameObject.tag == "asteroid") {
            // play boing sound
            Debug.Log("collision magnitude: " + collision.relativeVelocity.magnitude);
            this.ship.GetComponent<Lifecycle>().Damage(collision.relativeVelocity.magnitude);
            this.audio.Play();
        }
    }
}
