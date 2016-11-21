using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rigidbody;
	private int count;

	void Start () {
		rigidbody = GetComponent< Rigidbody >();
		count = 0;
		setCountText();
		winText.text = "";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed);

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count = count + 1;
			setCountText ();
			setWinText ();
		}
	}

	void setCountText () {
		countText.text = "Count: " + count.ToString();
	}
	void setWinText() {
		if (count == 10) {
			winText.text = "You Win!";
		}
	}
}