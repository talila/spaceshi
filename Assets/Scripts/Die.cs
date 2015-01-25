using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

    Component[] rigidbodies;
    Component[] fixedJoints;
    public float outOfControlMeasure = 10f;
    private bool dying = false;
    public float explosionPoint = -100f;

	// Use this for initialization
	void Start () {
        rigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>();
        fixedJoints = this.gameObject.GetComponentsInChildren<FixedJoint>();
	}
	
	// Update is called once per frame
	void Update () {
	   if (dying) {
            if (this.transform.position.y < explosionPoint) {
                Explode();
                this.dying = false;
            }
       }
	}

    public void Explode() {
        Debug.Log("explode");
        foreach (FixedJoint fixedJoint in fixedJoints) {
            Destroy(fixedJoint);
        }

        foreach (Rigidbody rigidbody in rigidbodies) {
            rigidbody.AddForce(Random.insideUnitSphere * outOfControlMeasure);
        }

        Invoke("Respawn", 2f);
    }

    public void Respawn() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void DieNow() {
        this.dying = true;
        foreach (Rigidbody rigidbody in rigidbodies) {
            rigidbody.useGravity = true;
            rigidbody.angularVelocity = Random.insideUnitSphere * outOfControlMeasure;
            rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

}
