using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deathstar : MonoBehaviour {

	[SerializeField]
	private Transform spaceship = null;
	[SerializeField]
	private List<Animator> doorAnimations = new List<Animator>();

	private bool doorIsOpen = false;

	private Transform myTransform = null;
	
	// Update is called once per frame
	void Update () {
		if(myTransform == null) {
			this.myTransform = this.transform;
		}

		if ((doorIsOpen==false) && (Vector3.Distance(spaceship.position, this.myTransform.position) < 11f))
		{
			foreach (CapsuleCollider c in spaceship.gameObject.GetComponents<CapsuleCollider>()) {
				c.height = 1;
			}
			int i = 1;
			foreach (Animator anim in this.doorAnimations)
			{
				anim.Play("door_" + i);
				i++;
			}
			this.doorIsOpen = true;
			Debug.Log("DOOR OPENED! " + (Vector3.Distance(spaceship.position, this.myTransform.position)));

		}
	}
}
