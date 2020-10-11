using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

	[SerializeField] float speed;
	bool finish = false;
	[SerializeField] Animator anim;
	bool run = false;
	Rigidbody2D rb;
	bool isGrounded;



	void Start(){
		rb = this.GetComponent<Rigidbody2D>();
		isGrounded = this.GetComponent<PlayerScript> ().isGrounded;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//transform.Translate (Vector3.right * speed * Time.deltaTime);
		if (finish) {
			isGrounded = this.GetComponent<PlayerScript> ().isGrounded;
			Debug.Log ("Setting mario's velocity: " + isGrounded);
			rb.AddForce(new Vector2((isGrounded?speed:0)*Time.fixedDeltaTime,0));
			Debug.Log (rb.velocity);

		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "FlagPole"){ 
			finish = true;

		}
	}
}
