using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {
	[SerializeField] float speed;
	[SerializeField] float lifeSpan;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifeSpan);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
}
