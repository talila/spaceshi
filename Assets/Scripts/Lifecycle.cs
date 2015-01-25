using UnityEngine;
using System.Collections;

public class Lifecycle : MonoBehaviour {

    public int maxHealth = 100;
    public int health = 100;
    public int damageMultiplier = 10;

    public GameObject[] healthDisplays;
    private HealthRenderer[] healthRenderer;

	void Start () {
        foreach (GameObject healthDisplay in healthDisplays) {
            healthDisplay.GetComponent<HealthRenderer>().RenderHealth(health/(float)maxHealth);
        }
	}
	
	void Update () {
        /*
        foreach (GameObject healthDisplay in healthDisplays) {
            healthDisplay.GetComponent<HealthRenderer>().RenderHealth(health/(float)maxHealth);
        }
        */
	}

    public void Damage(float force) {
        // calculate damage
         Debug.Log("damage force: " + force);
         this.health -= (int) (force * damageMultiplier);
        foreach (GameObject healthDisplay in healthDisplays) {
            healthDisplay.GetComponent<HealthRenderer>().RenderHealth(health/(float)maxHealth);
        }
        if (this.health <= 0) {
            Die dieScript = this.gameObject.GetComponent<Die>();
            dieScript.DieNow();
        }
    }
}
