using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagPoleScript : MonoBehaviour {

	AudioSource aud;
	[SerializeField] GameObject flag;



	// Use this for initialization
	void Start () {
		aud = this.gameObject.GetComponent<AudioSource> ();
		
	}
	
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("decsend");
			aud.Play ();
			flag.GetComponent<Animator> ().SetBool("FlagOn", true);
			//other.transform.parent = flag.transform;
			//other.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
			//other.transform.localPosition = Vector2.zero;
			//StartCoroutine (MarioSlide (other.gameObject));


		}

	}

	/*IEnumerator MarioSlide(GameObject Mario){

		Debug.Log("Mario slide");
		//while (flag.GetComponent<Animator> ()) {Debug.Log("Anim is playing");}

		yield return new WaitForSeconds (2);

		Mario.transform.parent = null;
		Mario.GetComponent<Rigidbody2D> ().isKinematic = false;
		Mario.transform.position = flag.transform.position;

		Debug.Log ("anin is done");
		//yield break;


	}*/
}
