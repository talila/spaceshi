using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidFactory : MonoBehaviour {

    private List<GameObject> asteroids;
    public int numberOfAsteroids = 300;
    public float fieldRadius = 150;
    public GameObject[] asteroidPrefabs;
    public float rotationSpeed = 1f;
    public float minScale = 0.5f;
    public float maxScale = 1.2f;
    public float minDistance = 6f;
    public bool checkForIntersections = true;

    private GameObject spaceship;

	// Use this for initialization
	void Awake () {
        spaceship = GameObject.Find("spaceship");
        asteroids = new List<GameObject>();
        if (checkForIntersections) {
            int n = 0;
            for(int i = 0; i < numberOfAsteroids; ++i) {
                bool intersecting = false;
                GameObject newAsteroid = (GameObject)Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], new Vector3(0,0,0), Quaternion.identity);
                newAsteroid.transform.parent = this.gameObject.transform;
                    
                int j = 0;
                do {
                    intersecting = false;
                    n++;
                    j++;
                    Vector3 randomPosition = Random.insideUnitSphere;
                    randomPosition.y = 0;
                    newAsteroid.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
                    Vector3 newPosition = randomPosition * fieldRadius;
                    newAsteroid.transform.position = newPosition;

                    foreach (GameObject asteroid in asteroids) {
                        float dist = Vector3.Distance(asteroid.transform.position, newPosition);
                        // check if this position is already occupied by another

                        if (dist < minDistance) {
                            intersecting = true;
                            Destroy(newAsteroid);
                            break;
                        }

                        // Debug.Log("other: " + asteroid.collider.bounds.min + ":" + asteroid.collider.bounds.max + ", new: " + newAsteroid.collider.bounds.min + ":" + newAsteroid.collider.bounds.max);
                            /*
                        if (asteroid.collider.bounds.Intersects(newAsteroid.collider.bounds)) {
                            intersecting = true;
                            Debug.Log("destroy new asteroid");
                            Destroy(newAsteroid);
                            break;
                        }
                        */
                    }

                    if (IntersectingWithShip(newAsteroid, spaceship)) {
                        intersecting = true;
                        Destroy(newAsteroid);
                        break;
                    }

                } while (intersecting && j<5);
            
                //newAsteroid.rigidbody.angularVelocity = Random.insideUnitSphere * rotationSpeed;
                if (j < 5) {
                    asteroids.Add(newAsteroid);
                }
            }

            Debug.Log("created " + numberOfAsteroids + " in " + n + "attempts");
        } else {
            for(int i = 0; i < numberOfAsteroids; ++i) {
                bool intersecting = false;
                Vector3 randomPosition = Random.insideUnitSphere;
                randomPosition.y = 0;
                GameObject newAsteroid = (GameObject)Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], randomPosition * fieldRadius, Quaternion.identity);
                newAsteroid.transform.parent = this.gameObject.transform;
                float size = Random.Range(minScale, maxScale);
                newAsteroid.transform.localScale = Vector3.one * size;

                if (IntersectingWithShip(newAsteroid, spaceship)) {
                    intersecting = true;
                    Destroy(newAsteroid);
                    break;
                }
            }
        }
        
        Invoke("ActivateColliders", 1);
	}

    public void ActivateColliders() {
        foreach (GameObject asteroid in asteroids) {
            if (asteroid != null) {
                asteroid.collider.enabled = true;
            }
        }
    }

    public bool IntersectingWithShip(GameObject asteroid, GameObject colliderTransform) {
        /*
        if (asteroid.collider.bounds.Intersects(colliderTransform.collider.bounds)) {
            return true;
        } else {
            return false;
        }
        */
        float dist = Vector3.Distance(asteroid.transform.position, colliderTransform.transform.position);
        // check if this position is already occupied by another

        if (dist < minDistance) {
            return true;
        } else {
            return false;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
