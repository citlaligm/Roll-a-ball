using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int counter;
	public Text score;
	public Text wintext;


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		counter = 0;
		setCountText ();
		wintext.text = "";
		//transform.transform.localScale += new Vector3(4.0f, 0, 0);
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical") ;
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			counter = counter + 1;
			setCountText ();
		}
	}

	void setCountText()
	{
		score.text = "Count: " + counter.ToString();
		if (counter >= 12) {
			wintext.text = "You win!";
		}
	}
}
