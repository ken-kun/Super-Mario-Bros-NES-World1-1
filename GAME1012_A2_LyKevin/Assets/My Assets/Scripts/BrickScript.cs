using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {
	AudioSource aud;
	[SerializeField] GameObject myCoin;
	//public float lifeTime;
	// Use this for initialization
	void Start () {
		aud = this.gameObject.GetComponent<AudioSource> ();

	}
	
	void OnCollisionEnter2D(Collision2D other)
	{

		if (other.gameObject.tag == "Player"){
			aud.Play ();
			aud = myCoin.GetComponent<AudioSource> ();
			aud.Play ();
			myCoin.GetComponent<Animator> ().enabled = true;

			//Destroy (gameObject, lifeTime);

	 
		}
	}




}
