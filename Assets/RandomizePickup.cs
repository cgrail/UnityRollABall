using UnityEngine;
using System.Collections;

public class RandomizePickup : MonoBehaviour {

	public GameObject pickupTemplate;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 12; i++) {
			Instantiate (pickupTemplate, new Vector3 (getRandomValue(), 1.3f, getRandomValue()), Quaternion.identity);
		}
	}

	float getRandomValue () {
		return (Random.value * 17.5f) - 8.75f;
	}

}
