using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFireballBehaviour : MonoBehaviour {

	Rigidbody2D rb2D;
	protected Vector3 origin = new Vector3();

	// Use this for initialization
	void Start () {
		rb2D = transform.GetComponent<Rigidbody2D>();
		Vector2 direction = transform.position - origin;
		direction.Normalize();
		float projectileSpeed = 8;
		rb2D.velocity = direction * projectileSpeed;
		Vector2 moveDirection = rb2D.velocity;
		if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnCollisionEnter2D(Collision2D other){
		print("First point that collided: " + other.contacts[0].point);
		Debug.Log(other.contacts.Length);
		Destroy(this.gameObject);
	}
	public void setOrigin(Vector3 vector){
		origin = vector;
	}
}