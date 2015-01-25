using UnityEngine;
using System.Collections;

public class DeathstarDestination : MonoBehaviour {

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.name.Equals("spaceship"))
		{
			this.PlayLevelEnd();
		}
	}

	private void PlayLevelEnd()
	{
		Debug.Log("LEVEL FINISHED!");
	}
}
