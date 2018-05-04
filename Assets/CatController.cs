using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;
	public float gravity;
	private Animator anim;
	private SpriteRenderer sprite;
	private bool jump;
	public bool grounded;
	public float impulse;
	private int jumpCount;
	public Collider2D feetCollider;

	void Start () {

		rb = GetComponent<Rigidbody2D>();

		anim = GetComponent<Animator>();

		sprite = GetComponent<SpriteRenderer>();

		jumpCount = 0;

	}

	void Update () {

		anim.SetFloat("speed", rb.velocity.x / speed);

		anim.SetFloat("vspeed", rb.velocity.y);

		if ( rb.velocity.x < -0.1f )
			sprite.flipX = true;

		if ( rb.velocity.x > 0.1f )
			sprite.flipX = false;

		grounded = feetCollider.IsTouchingLayers(1 << 8);

		anim.SetBool("grounded", grounded);

		if ( grounded && Input.GetButtonDown("Jump") ) {
			jump = true;
			jumpCount = 0;
		} else if ( jumpCount < 1 && Input.GetButtonDown("Jump") ) {
			jump = true;
			jumpCount++;
		}

	}

	void FixedUpdate() {

		Vector2 newVelocity;

		newVelocity = rb.velocity;

		newVelocity.x = Input.GetAxis("Horizontal") * speed;

		if ( jump ) {

			newVelocity.y = impulse;

			jump = false;
				
		}

		newVelocity.y = Mathf.Clamp(newVelocity.y, -impulse, impulse);

		rb.velocity = newVelocity;

		rb.AddForce(new Vector2(0, -gravity));

		if ( Input.GetButton("Jump") )
			rb.AddForce(new Vector2(0, gravity/2));  

	}

}
