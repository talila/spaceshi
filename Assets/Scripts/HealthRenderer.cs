using UnityEngine;
using System.Collections;

public class HealthRenderer : MonoBehaviour {

    private Gradient g;
    public GradientColorKey[] colorKeys;
    public GradientAlphaKey[] alphaKeys;

    public float health = 1f;

	// Use this for initialization
	void Start () {
	   g = new Gradient();

         // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKeys = new GradientColorKey[2];
        colorKeys[0].color = Color.green;
        colorKeys[0].time = 1.0f;
        colorKeys[1].color = Color.red;
        colorKeys[1].time = 0.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 1.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 0.0f;

        g.SetKeys(colorKeys, alphaKeys);

        RenderHealth(health);
	}
	
	// Update is called once per frame
	void Update () {
	   // RenderHealth(this.health);
	}

    public void RenderHealth(float health) {
        this.gameObject.renderer.material.color = g.Evaluate(health);
    }
}
