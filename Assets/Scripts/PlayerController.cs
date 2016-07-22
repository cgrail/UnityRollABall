using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		updateCount ();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			updateCount ();
		}
	}

	void updateCount() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win";
			Scene currentScene = SceneManager.GetActiveScene ();
			SceneManager.UnloadScene (currentScene.buildIndex);
			SceneManager.LoadScene (currentScene.buildIndex);
		}
	}

}
