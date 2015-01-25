using UnityEngine;
using System.Collections;

public class goalArrow : MonoBehaviour {

	[SerializeField]
	private Transform goal;

	void Update () {
		Vector2 goalDir = new Vector2(goal.position.z, goal.position.x) - new Vector2(transform.position.z, transform.position.x);
		float angle = Mathf.Sign(goalDir.y) * Vector2.Angle(goalDir, Vector2.right);
		transform.rotation = Quaternion.Euler(0, angle, 0);
	}
}
