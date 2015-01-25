using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    public float speed = .5f;
    public float secondsUntilDestroy = 10f;

    private float startTime;

    void Start () {
        this.startTime = Time.time;
		tag = "shot";
		rigidbody.AddForce (-transform.up * speed);

    }
    
    void FixedUpdate () {
        if (Time.time - startTime >= secondsUntilDestroy) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
			Destroy(this.gameObject);
    }

}
