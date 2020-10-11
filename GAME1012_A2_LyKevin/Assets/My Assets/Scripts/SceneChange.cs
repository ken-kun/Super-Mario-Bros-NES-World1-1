using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] float loadDelay;
	AudioSource aud;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			aud = this.gameObject.GetComponent<AudioSource> ();
			aud.Play();
			Invoke ("LoadScene", loadDelay);
		}
	}

	void LoadScene(){
		SceneManager.LoadScene("Scene3");

	}
}
