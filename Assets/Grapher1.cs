using UnityEngine;
using System.Collections;

public class Grapher1 : MonoBehaviour {
	
	public int resolution = 10;
	
	private int currentResolution;
	private ParticleSystem.Particle[] points;
		
	// Use this for initialization
	void Start () {
		CreatePoints();
	}
	
	private void CreatePoints() {
		// prevent divide by zero
		if (resolution < 2) {
			resolution = 2;
		}
		currentResolution = resolution;
		
		points = new ParticleSystem.Particle[resolution];		
		float increment = 1f / (resolution - 1);
		for(int i = 0; i < resolution; i++){
			float x = i * increment;
			points[i].position = new Vector3(x, 0f, 0f);
			points[i].color = new Color(x, 0f, 0f);
			points[i].size = 0.1f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentResolution != resolution) {
			CreatePoints();
		}
		
		particleSystem.SetParticles(points, points.Length);
	}
}
