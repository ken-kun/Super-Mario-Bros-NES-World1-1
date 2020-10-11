using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour {
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float maxVelocity;
    [SerializeField] float horzJumpDamping;
	[SerializeField] GameObject projectile;
	[SerializeField] GameObject spawnFire;
	[SerializeField] Transform spawnPoint;
	[SerializeField] AudioClip deathClip;
    AudioSource aud;
	bool isDead;
    public bool isGrounded;
    bool jumping = false;
    float axis = 0;
    Rigidbody2D rb;

	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        aud = this.GetComponent<AudioSource>();
	}
	
	void Update () {

		if (isDead == true)
			return;
		


        axis = Input.GetAxis("Horizontal");
        if (axis < 0) transform.localScale = new Vector3(-1,1,1);
        else if (axis > 0) transform.localScale = new Vector3(1,1,1);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
            jumping = true;
		anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); // Might be able to change this to trigger anim
        anim.SetFloat("Resist", (Mathf.Abs((Input.GetAxisRaw("Horizontal") - Input.GetAxis("Horizontal")))));
        anim.SetBool("Jumping", !isGrounded);

		if (Input.GetButtonDown ("Fire1")) {
			//aud = spawnFire.GetComponent < AudioSource> ();
			//aud.Play ();
			Instantiate (projectile, spawnPoint.position, spawnPoint.rotation);
		}
	}

    void FixedUpdate() {
        if (jumping == true) {
            aud.Play();
            rb.AddForce(new Vector2(0,jumpForce*Time.fixedDeltaTime));
            jumping = false;
        }
        rb.AddForce(new Vector2(axis*(isGrounded?moveSpeed:moveSpeed/horzJumpDamping)*Time.fixedDeltaTime,0));
    }

    void OnTriggerEnter2D (Collider2D other) {

		Debug.Log (other.name);
		if (other.tag == "Ground")
            isGrounded = true;

		if ((other.tag == "Pit" || other.tag == "Enemy") && (!isDead)) {
			aud.clip = deathClip;
			aud.Play ();
			isDead = true;
			rb.velocity = Vector2.zero;
			rb.AddForce (new Vector2 (0, 500));
			isGrounded = true;
			anim.SetBool("Death", true);
			Debug.Log ("death");

			//this.enabled = false;

		}
    }

    void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Ground" && !isDead)
            isGrounded = false;
		
    }

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "Ground") {
			isGrounded = true;
			}

	}



}
